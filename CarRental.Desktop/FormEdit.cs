using CarRental.BL.Contract.Model;
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
                ? new Car(){ Id = Guid.NewGuid(),  Mileage = 1, AvgFuelConsumption = 1, FuelVolume = 1, RentalCost = 1 } 
                : source.Clone();

            textBoxCarMake.AddBinding(x => x.Text, Car, x => x.CarMake, errorFilling);
            textBoxStateNumber.AddBinding(x => x.Text, Car, x => x.StateNumber, errorFilling);
            numericMileage.AddBinding(x => x.Value, Car, x => x.Mileage);
            numericAvgFuelConumption.AddBinding(x => x.Value, Car, x => x.AvgFuelConsumption);
            numericFuelVolume.AddBinding(x => x.Value, Car, x => x.FuelVolume);
            numericRentalCost.AddBinding(x => x.Value, Car, x => x.RentalCost);
        }

        public Car Car { get; }
    }
}
