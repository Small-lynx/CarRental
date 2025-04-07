using CarRental.BL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.SQL
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(string connectionString) 
            : base(connectionString) { }

        /// <summary>
        /// Список студентов
        /// </summary>
        public DbSet<Car> Cars {  get; set; }
    }
}
