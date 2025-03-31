using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CarRental.Storage.InMemory
{
    public class CarInMemoryStorage : IStorage<Car>
    {
        private readonly List<Car> items;
        private readonly ILogger logger;
        private readonly Stopwatch stopwatch = new();

        public CarInMemoryStorage(ILogger logger)
        {
            this.logger = logger;
            items = new List<Car>();
            items =
            [
                 new Car
                {
                    Id = Guid.NewGuid(),
                    CarMake = "Хёндай крета",
                    StateNumber = "A123AE95",
                    Mileage = 12580,
                    AvgFuelConsumption = 4.8m,
                    FuelVolume = 12.0m,
                    RentalCost = 11.48m,
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    CarMake = "Лада веста",
                    StateNumber = "B456BK165",
                    Mileage = 15967,
                    AvgFuelConsumption = 4.6m,
                    FuelVolume = 19.2m,
                    RentalCost = 12.56m,
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    CarMake = "Митсубиси аутлендер",
                    StateNumber = "C789CM01",
                    Mileage = 9046,
                    AvgFuelConsumption = 5.1m,
                    FuelVolume = 3.0m,
                    RentalCost = 15.34m,
                },
            ];
        }

        Task IStorage<Car>.Add(Car item, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            items.Add(item);
            stopwatch.Stop();
            logger.LogInformation("Новый автомобиль с ID {Id}  добавлен в память - {@item}", item.Id, item);
            logger.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return Task.CompletedTask;
        }

        Task IStorage<Car>.Delete(Guid ID, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var item = items.First(x => x.Id == ID);
            items.Remove(item);
            stopwatch.Stop();
            logger.LogInformation("Автомобиль с ID {Id}  удален из памяти - {@item}", item.Id, item);
            logger.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return Task.CompletedTask;
        }

        Task IStorage<Car>.Edit(Guid ID, Car item, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            items[items.IndexOf(items.First(x => x.Id == ID))] = item;
            stopwatch.Stop();
            logger.LogInformation("Автомобиль с ID {Id}  изменен в памяти - {@item}", ID, item);
            logger.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return Task.CompletedTask;
        }

        Task<Car?> IStorage<Car>.Get(Guid ID, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var item = Task.FromResult(items.FirstOrDefault(x => x.Id == ID));
            stopwatch.Stop();
            logger.LogInformation("Автомобиль с ID {Id}  получен из памяти", ID);
            logger.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return item;
        }

        Task<IReadOnlyCollection<Car>> IStorage<Car>.GetAll(CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var item = Task.FromResult((IReadOnlyCollection<Car>)new ReadOnlyCollection<Car>(items));
            stopwatch.Stop();
            logger.LogInformation("Получен список всех автомобилей из памяти");
            logger.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return item;
        }
    }
}
