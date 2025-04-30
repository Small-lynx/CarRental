using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Storage.SQL
{
    public class CarRentalStorage(string connectionString, ILogger? logger) : IStorage<Car>
    {
        private readonly string connectionString = connectionString;
        private readonly ILogger logger = logger;

        async Task IStorage<Car>.Add(Car item, CancellationToken cancellationToken)
        {
            using var context = new CarRentalContext(connectionString);
            context.Cars.Add(item);
            logger?.LogInformation("Новый автомобиль с ID {Id}  добавлен в БД - {@item}", item.Id, item);
            await context.SaveChangesAsync(cancellationToken);
        }

        async Task IStorage<Car>.Delete(Guid ID, CancellationToken cancellationToken)
        {
            using var context = new CarRentalContext(connectionString);
            var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == ID, cancellationToken);
            context.Cars.Remove(car);
            logger?.LogInformation("Автомобиль с ID {Id}  удален из БД - {@item}", ID, car);
            await context.SaveChangesAsync(cancellationToken);
        }

        async Task IStorage<Car>.Edit(Guid ID, Car item, CancellationToken cancellationToken)
        {
            using var context = new CarRentalContext(connectionString);
            var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == ID, cancellationToken);

            car.CarMake = item.CarMake;
            car.StateNumber = item.StateNumber;
            car.Mileage = item.Mileage;
            car.AvgFuelConsumption = item.AvgFuelConsumption;
            car.FuelVolume = item.FuelVolume;
            car.RentalCost = item.RentalCost;
            logger?.LogInformation("Автомобиль с ID {Id}  изменен в БД - {@item}", ID, car);

            await context.SaveChangesAsync(cancellationToken);
        }

        async Task<Car?> IStorage<Car>.Get(Guid ID, CancellationToken cancellationToken)
        {
            using var context = new CarRentalContext(connectionString);
            var result = await context.Cars.FirstOrDefaultAsync(x => x.Id == ID, cancellationToken);
            logger?.LogInformation("Автомобиль с ID {Id}  получен из БД", ID);
            return result;
        }

        async Task<IReadOnlyCollection<Car>> IStorage<Car>.GetAll(CancellationToken cancellationToken)
        {
            using var context = new CarRentalContext(connectionString); 
            var result = await context.Cars
                .OrderBy(x => x.Id)
                .ToListAsync(cancellationToken);
            logger?.LogInformation("Получен список всех автомобилей из БД");
            return result;
        }
    }
}
