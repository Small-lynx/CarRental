using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;

namespace CarRental.BL
{
    /// <inheritdoc cref="ICarManeger"/>
    public partial class CarManeger(IStorage<Car> storage) : ICarManeger
    {
        private readonly IStorage<Car> storage = storage;

        Task<IReadOnlyCollection<Car>> ICarManeger.GetCars(CancellationToken cancellationToken)
            => storage.GetAll(cancellationToken);

        Task<Car> ICarManeger.Add(CarRequest request, CancellationToken cancellationToken)
        {
            var item = Validation(Guid.Empty, request);
            storage.Add(item, cancellationToken);
            return Task.FromResult(item);
        }

        async Task ICarManeger.Delete(Guid ID, CancellationToken cancellationToken)
        {
            var item = await storage.Get(ID, cancellationToken) ??
                throw new InvalidOperationException("Не удалось найти машину с данным ID");
            await storage.Delete(item.Id, cancellationToken);
        }

        async Task<Car> ICarManeger.Edit(Guid ID, CarRequest request, CancellationToken cancellationToken)
        {
            if (storage.Get(ID, cancellationToken) != null)
            {
                var item = Validation(ID, request);
                await storage.Edit(ID, item, cancellationToken);
                return item;
            }
            throw new InvalidOperationException("Не удалось найти машину с данным ID");
            
        }
        async Task<CarStatustic> ICarManeger.GetStatistic(CancellationToken cancellationToken)
        {
            var items = await storage.GetAll(cancellationToken);
            var countRent = items.Count;
            var countFuel = items.Where(x => x.FuelVolume <= 7).Count();

            return new CarStatustic(countRent, countFuel);
        }

        /// <summary>
        /// Проверка данных машины 
        /// </summary>
        private static Car Validation(Guid ID, CarRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(request.CarMake);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(request.StateNumber);
            ArgumentOutOfRangeException.ThrowIfNegative(request.Mileage);
            ArgumentOutOfRangeException.ThrowIfNegative(request.AvgFuelConsumption);
            ArgumentOutOfRangeException.ThrowIfNegative(request.FuelVolume);
            ArgumentOutOfRangeException.ThrowIfNegative(request.RentalCost);

            var item = new Car
            {
                Id = ID == Guid.Empty ? Guid.NewGuid() : ID,
                CarMake = request.CarMake,
                StateNumber = request.StateNumber,
                Mileage = request.Mileage,
                AvgFuelConsumption = request.AvgFuelConsumption,
                FuelVolume = request.FuelVolume,
                RentalCost = request.RentalCost,
            };

            return item;
        }
    }
}
