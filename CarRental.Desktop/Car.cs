using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Desktop
{
    /// <summary>
    /// Машина для проката
    /// </summary>
    public class Car
    {
        /// <summary>
        /// ID машины
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Марка машины
        /// </summary>
        public string? CarMake { get; set; }
        /// <summary>
        /// Гос номер
        /// </summary>
        public string? StateNumber { get; set; }
        /// <summary>
        /// Пробег
        /// </summary>
        public decimal Mileage { get; set; }
        /// <summary>
        /// Средний расход топлива за час
        /// </summary>
        public decimal AvgFuelConsumption { get; set; }
        /// <summary>
        /// Текущий объем топлива
        /// </summary>
        public decimal FuelVolume { get; set; }
        /// <summary>
        /// Стоимость аренды (за минуту)
        /// </summary>
        public decimal RentalCost { get; set; }
    }
}
