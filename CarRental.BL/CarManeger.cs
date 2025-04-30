using CarRental.BL.Contract;
using CarRental.BL.Contract.Model;
using CarRental.Storage.Contract;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CarRental.BL
{
    /// <inheritdoc cref="ICarManeger"/>
    public partial class CarManeger(IStorage<Car> storage, ILogger? logger) : ICarManeger
    {
        private readonly IStorage<Car> storage = storage;
        private readonly ILogger logger = logger;
        private readonly Stopwatch stopwatch = new();

        Task<IReadOnlyCollection<Car>> ICarManeger.GetCars(CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var items = storage.GetAll(cancellationToken);
            stopwatch.Stop();
            logger?.LogInformation("Получен список всех автомобилей");
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return items;
        }

        Task<Car?> ICarManeger.GetCar(Guid id,CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var items = storage.Get(id, cancellationToken);
            stopwatch.Stop();
            logger?.LogInformation("Получен автомобиль с id {id}", id);
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return items;
        }

        Task<Car> ICarManeger.Add(CarRequest request, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var item = Validation(Guid.Empty, request);
            storage.Add(item, cancellationToken);
            stopwatch.Stop();
            logger?.LogInformation("Добавлен новый автомобиль с ID {Id} - {@item}", item.Id, item);
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            return Task.FromResult(item);
        }

        async Task ICarManeger.Delete(Guid ID, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var item = await storage.Get(ID, cancellationToken);
            if (item == null)
            {
                stopwatch.Stop();
                logger?.LogError("Не удалось найти машину с данным ID - {@id}", ID);
                logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
                throw new InvalidOperationException("Не удалось найти машину с данным ID");
            }
            await storage.Delete(item.Id, cancellationToken);
            stopwatch.Stop();
            logger?.LogInformation("Удален автомобиль с ID {Id} - {@item}", ID, item);
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
        }

        async Task<Car> ICarManeger.Edit(Guid ID, CarRequest request, CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            if (storage.Get(ID, cancellationToken) != null)
            {
                var item = Validation(ID, request);
                await storage.Edit(ID, item, cancellationToken);
                stopwatch.Stop();
                logger?.LogInformation("Изменен автомобиль с ID {Id} - {@item}", ID, item);
                logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
                return item;
            }
            stopwatch.Stop();
            logger?.LogError("Не удалось найти машину с данным ID - {@id}", ID);
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
            throw new InvalidOperationException("Не удалось найти машину с данным ID");
            
        }
        async Task<CarStatustic> ICarManeger.GetStatistic(CancellationToken cancellationToken)
        {
            stopwatch.Restart();
            var items = await storage.GetAll(cancellationToken);
            var countRent = items.Count;
            var countFuel = items.Where(x => x.FuelVolume <= 7).Count();

            stopwatch.Stop();
            logger?.LogInformation("Получена статистика авомобилей. Количество машин в прокате - {count}, кол-во машин с критическим уровнем топлива - {countFuel}", countRent, countFuel);
            logger?.LogInformation("Метод выполнен за {stopwatch} мс", stopwatch);
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
