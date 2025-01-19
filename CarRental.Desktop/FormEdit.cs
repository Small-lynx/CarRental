using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Desktop
{
    public partial class FormEdit : Form
    {
        public FormEdit(Car? source = null)
        {
            InitializeComponent();
            Car = source == null 
                ? new Car() { Id = Guid.NewGuid() } 
                : new Car() 
                { 
                    Id = source.Id,
                    CarMake = source.CarMake,
                    StateNumber = source.StateNumber,
                    Mileage = source.Mileage,
                    AvgFuelConsumption = source.AvgFuelConsumption,
                    FuelVolume = source.FuelVolume,
                    RentalCost = source.RentalCost,
                };
            textBoxCarMake.Text = Car.CarMake;
            textBoxStateNumber.Text = Car.StateNumber;
            numericMileage.Value = Car.Mileage;
            numericAvgFuelConumption.Value = Car.AvgFuelConsumption;
            numericFuelVolume.Value = Car.FuelVolume;
            numericRentalCost.Value = Car.RentalCost;
        }

        public Car Car { get; }

        private void textBoxCarMake_TextChanged(object sender, EventArgs e)
        {
            Car.CarMake = textBoxCarMake.Text;
        }

        private void textBoxStateNumber_TextChanged(object sender, EventArgs e)
        {
            Car.StateNumber = textBoxStateNumber.Text;
        }

        private void numericMileage_ValueChanged(object sender, EventArgs e)
        {
            Car.Mileage = numericMileage.Value;
        }

        private void numericAvgFuelConumption_ValueChanged(object sender, EventArgs e)
        {
            Car.AvgFuelConsumption = numericAvgFuelConumption.Value;
        }

        private void numericFuelVolume_ValueChanged(object sender, EventArgs e)
        {
            Car.FuelVolume = numericFuelVolume.Value;
        }

        private void numericRentalCost_ValueChanged(object sender, EventArgs e)
        {
            Car.RentalCost = numericRentalCost.Value;
        }
    }
}
