using System.Drawing.Text;

namespace CarRental.Desktop
{
    public partial class MainForm : Form
    {
        private readonly List<Car> cars;
        private readonly BindingSource carsBinding;
        public MainForm()
        {
            InitializeComponent();
            cars =
            [
                new Car
                {
                    CarMake = "Хёндай крета",
                    StateNumber = "A123AE95",
                    Mileage = 12580,
                    AvgFuelConsumption = 4.8m,
                    FuelVolume = 12.0m,
                    RentalCost = 11.48m
                },
                new Car
                {
                    CarMake = "Лада веста",
                    StateNumber = "B456BK165",
                    Mileage = 15967,
                    AvgFuelConsumption = 4.6m,
                    FuelVolume = 19.2m,
                    RentalCost = 12.56m
                },
                new Car
                {
                    CarMake = "Митсубиси аутлендер",
                    StateNumber = "C789CM01",
                    Mileage = 9046,
                    AvgFuelConsumption = 5.1m,
                    FuelVolume = 3.0m,
                    RentalCost = 15.34m
                },
            ];

            carsBinding = new()
            {
                DataSource = cars
            };
            DataGridCar.AutoGenerateColumns = false;
            DataGridCar.DataSource = carsBinding;
            CalculationOfChanges();
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
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (DataGridCar.SelectedRows.Count > 0 &&
                DataGridCar.SelectedRows[0].DataBoundItem is Car car)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить машину {car.StateNumber}",
                    "Удаление машины",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var target = cars.FirstOrDefault(x => x.Id == car.Id);
                    if (target != null)
                    {
                        cars.Remove(target);
                        CalculationOfChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Добавление машины
        /// </summary>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var editForm = new FormEdit();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                cars.Add(editForm.Car);
                CalculationOfChanges();
            }
        }

        /// <summary>
        /// Изменение данных машины
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridCar.SelectedRows.Count > 0 &&
                DataGridCar.SelectedRows[0].DataBoundItem is Car car)
            {
                var editForm = new FormEdit(car);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    car.CarMake = editForm.Car.CarMake;
                    car.StateNumber = editForm.Car.StateNumber;
                    car.Mileage = editForm.Car.Mileage;
                    car.AvgFuelConsumption = editForm.Car.AvgFuelConsumption;
                    car.FuelVolume = editForm.Car.FuelVolume;
                    car.RentalCost = editForm.Car.RentalCost;
                    CalculationOfChanges();
                }
            }
        }

        private void CalculationOfChanges()
        {
            carsBinding.ResetBindings(false);

            //toolStripCar
            toolStripStatusAllCar.Text = $"Кол-во автомобилей в прокате - {cars.Count}";
            var countCar = cars.Where(x => x.FuelVolume <= 7).Count();
            toolStripStatusLowFuel.Text = $"Кол-во автомобилей с критическим уровнем топлива - {countCar}";
        }
    }
}
