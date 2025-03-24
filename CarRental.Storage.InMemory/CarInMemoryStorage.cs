using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using System.Collections.ObjectModel;

namespace CarRental.Storage.InMemory
{
    public class CarInMemoryStorage : IStorage<Car>
    {
        private readonly List<Car> items;

        public CarInMemoryStorage()
        {
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
            items.Add(item);
            return Task.CompletedTask;
        }

        Task IStorage<Car>.Delete(Guid ID, CancellationToken cancellationToken)
        {
            var item = items.First(x => x.Id == ID);
            items.Remove(item);
            return Task.CompletedTask;
        }

        Task IStorage<Car>.Edit(Guid ID, Car item, CancellationToken cancellationToken)
        {
            items[items.IndexOf(items.First(x => x.Id == ID))] = item;
            return Task.CompletedTask;
        }

        Task<Car?> IStorage<Car>.Get(Guid ID, CancellationToken cancellationToken) 
            => Task.FromResult(items.FirstOrDefault(x => x.Id == ID));

        Task<IReadOnlyCollection<Car>> IStorage<Car>.GetAll(CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyCollection<Car>)new ReadOnlyCollection<Car>(items));
    }
}
