using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
namespace CarRental.Desktop
{
    public partial class MainForm : Form
    {
        private readonly BindingSource carsBinding;
        private readonly ICarManeger carManeger;

        public MainForm(ICarManeger carManeger)
        {
            InitializeComponent();
            carsBinding = new BindingSource();
            this.carManeger = carManeger;
            DataGridCar.AutoGenerateColumns = false;
            DataGridCar.DataSource = carsBinding;
        }

        /// <summary>
        /// Заполнение вычисляемых столбцов
        /// </summary>
        private void DataGridCar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var car = DataGridCar.Rows[e.RowIndex].DataBoundItem as Car;
            if (car == null)
            {
                return;
            }

            if (DataGridCar.Columns[e.ColumnIndex].Name == nameof(ColumnRangeFuel))
            {
                e.Value = Math.Round(car.FuelVolume / car.AvgFuelConsumption, 2);
            }

            if (DataGridCar.Columns[e.ColumnIndex].Name == nameof(ColumnRentalAmount))
            {
                e.Value = Math.Round((car.FuelVolume / car.AvgFuelConsumption) * car.RentalCost * 60, 2);
            }

            if (DataGridCar.Columns[nameof(ColumnFuel)].Index == e.ColumnIndex && e.RowIndex > -1)
            {
                e.CellStyle!.BackColor = (decimal)e.Value! <= 7.0m ? Color.Red : Color.Green;
            }
        }

        /// <summary>
        /// Удаление машины
        /// </summary>
        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridCar.SelectedRows.Count > 0 &&
                DataGridCar.SelectedRows[0].DataBoundItem is Car car)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить машину {car.StateNumber}",
                    "Удаление машины",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await carManeger.Delete(car.Id, CancellationToken.None);
                    await CalculationOfChanges(CancellationToken.None);
                }
            }
        }

        /// <summary>
        /// Добавление машины
        /// </summary>
        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var editForm = new FormEdit();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await carManeger.Add(new CarRequest(editForm.Car.CarMake,
                    editForm.Car.StateNumber,
                    editForm.Car.Mileage,
                    editForm.Car.AvgFuelConsumption,
                    editForm.Car.FuelVolume,
                    editForm.Car.RentalCost),
                    CancellationToken.None);
                await CalculationOfChanges(CancellationToken.None);
            }
        }

        /// <summary>
        /// Изменение данных машины
        /// </summary>
        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridCar.SelectedRows.Count > 0 &&
                DataGridCar.SelectedRows[0].DataBoundItem is Car car)
            {
                var editForm = new FormEdit(car);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await carManeger.Edit(car.Id, new CarRequest(editForm.Car.CarMake,
                        editForm.Car.StateNumber,
                        editForm.Car.Mileage,
                        editForm.Car.AvgFuelConsumption,
                        editForm.Car.FuelVolume,
                        editForm.Car.RentalCost),
                        CancellationToken.None);
                    await CalculationOfChanges(CancellationToken.None);
                }
            }
        }

        private async Task CalculationOfChanges(CancellationToken cancellationToken)
        {
            var result = await carManeger.GetStatistic(CancellationToken.None);
            //toolStripCar
            toolStripStatusAllCar.Text = $"Кол-во автомобилей в прокате - {result.countRent}";
            toolStripStatusLowFuel.Text = $"Кол-во автомобилей с критическим уровнем топлива - {result.countFuel}";

            carsBinding.DataSource = await carManeger.GetCars(CancellationToken.None);
            carsBinding.ResetBindings(false);
        }

        /// <summary>
        /// Действия при загрузке формы
        /// </summary>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await CalculationOfChanges(CancellationToken.None);
        }
    }
}
