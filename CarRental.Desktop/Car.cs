using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Марка машины
        /// </summary>
        [Required(ErrorMessage = "Не заполнена марка машины")]
        public string? CarMake { get; set; }

        /// <summary>
        /// Гос номер
        /// </summary>
        [Required(ErrorMessage = "Не заполнен гос номер")]
        [RegularExpression(@"^[A-Z]{1}[0-9]{3}[A-Z]{2}[0-9]{1,3}$", ErrorMessage = "Строка не соответствует шаблону A000AA00")]
        public string? StateNumber { get; set; }

        /// <summary>
        /// Пробег
        /// </summary>
        [Required(ErrorMessage = "Не заполнен пробег машины")]
        
        public decimal Mileage { get; set; }

        /// <summary>
        /// Средний расход топлива за час
        /// </summary>
        [Required(ErrorMessage = "Не заполнена расход топлива ")]
        public decimal AvgFuelConsumption { get; set; }

        /// <summary>
        /// Текущий объем топлива
        /// </summary>
        [Required(ErrorMessage = "Не заполнен объем топлива")]
        public decimal FuelVolume { get; set; }

        /// <summary>
        /// Стоимость аренды (за минуту)
        /// </summary>
        [Required(ErrorMessage = "Не заполнена стоимость аренды")]
        public decimal RentalCost { get; set; }

        /// <summary>
        /// Создание дубликата прокатной машины
        /// </summary>
        /// <returns></returns>
        public Car Clone()
        {
            return (Car)MemberwiseClone();
        }
    }
}
