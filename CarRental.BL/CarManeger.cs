using CarRental.BL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BL
{
    public partial class CarManeger
    {
        private readonly List<Car> Cars;

        public CarManeger()
        {
            Cars = 
            [
                 new Car
                {
                    CarMake = "Хёндай крета",
                    StateNumber = "A123AE95",
                    Mileage = 12580,
                    AvgFuelConsumption = 4.8m,
                    FuelVolume = 12.0m,
                    RentalCost = 11.48m,
                },
                new Car
                {
                    CarMake = "Лада веста",
                    StateNumber = "B456BK165",
                    Mileage = 15967,
                    AvgFuelConsumption = 4.6m,
                    FuelVolume = 19.2m,
                    RentalCost = 12.56m,
                },
                new Car
                {
                    CarMake = "Митсубиси аутлендер",
                    StateNumber = "C789CM01",
                    Mileage = 9046,
                    AvgFuelConsumption = 5.1m,
                    FuelVolume = 3.0m,
                    RentalCost = 15.34m,
                },
            ];

        }

        /// <summary>
        /// Возвращает список <see cref="Car"/>
        /// </summary>
        public Task<IReadOnlyCollection<Car>> GetCars(CancellationToken cancellationToken) 
            => Task.FromResult((IReadOnlyCollection<Car>) new ReadOnlyCollection<Car>(Cars));

        /// <summary>
        /// Добавление манины
        /// </summary>
        public Task<Car> Add(CarRequest request, CancellationToken cancellationToken)
        {
            var item = Validation(Guid.Empty, request);
            Cars.Add(item);
            return Task.FromResult(item);
        }

        /// <summary>
        /// Удаление машины
        /// </summary>
        public async Task Delete(Guid ID, CancellationToken cancellationToken) 
        { 
            var item = Cars.FirstOrDefault(x => x.Id == ID) ?? 
                throw new InvalidOperationException("Не удалось найти машину с данным ID");
            Cars.Remove(item);
        }

        /// <summary>
        /// Изменение данных машины
        /// </summary>
        public async Task<Car> Edit(Guid ID, CarRequest request, CancellationToken cancellationToken)
        {
           var item = Validation(ID, request);
            Cars[Cars.FindIndex(x => x.Id == ID)] = item;
            return item;
        }

        /// <summary>
        /// Возвращяет статистику <see cref="CarStatustic"/>
        /// </summary>
        public Task<CarStatustic> GetStatistic(CancellationToken cancellationToken)
        {
            var countRent = Cars.Count;
            var countFuel = Cars.Where(x => x.FuelVolume <= 7).Count();

            return Task.FromResult(new CarStatustic(countRent, countFuel));
        }

        /// <summary>
        /// Проверка данных машины 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="request"></param>
        /// <returns></returns>
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
                Id = ID == Guid.Empty ? Guid.NewGuid(): ID,
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
