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
                    StateNumber = "AA123E",
                    Mileage = 12580,
                    AvgFuelConsumption = 4.8m,
                    FuelVolume = 12.0m,
                    RentalCost = 11.48m
                },
                new Car
                {
                    CarMake = "Лада веста",
                    StateNumber = "BB456K",
                    Mileage = 15967,
                    AvgFuelConsumption = 4.6m,
                    FuelVolume = 19.2m,
                    RentalCost = 12.56m
                },
                new Car
                {
                    CarMake = "Митсубиси аутлендер",
                    StateNumber = "CC789M",
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

            //toolStripCar
            toolStripStatusAllCar.Text = $"Кол-во автомобилей в прокате - {cars.Count}";
            var countCar = 0;
            foreach (var item in cars)
            {
                if (item.FuelVolume <= 7)
                {
                    countCar += 1;
                }
            }
            toolStripStatusLowFuel.Text = $"Кол-во автомобилей с критическим уровнем топлива - {countCar}";
        }

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
        }

        private void DataGridCar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (DataGridCar.Columns[nameof(ColumnFuel)].Index == e.ColumnIndex && e.RowIndex > -1)
            {
                decimal fuel = decimal.Parse(s: e.Value?.ToString());
                if (fuel <= 7.0m)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }
        }
    }
}
