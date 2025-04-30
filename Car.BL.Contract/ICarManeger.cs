using CarRental.BL.Contract.Model;

namespace CarRental.BL.Contract
{
    /// <summary>
    /// Менеджер по управлению <see cref="Car"/>
    /// </summary>
    public interface ICarManeger
    {
        /// <summary>
        /// Добавление манины
        /// </summary>
        Task<Car> Add(CarRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление машины
        /// </summary>
        Task Delete(Guid ID, CancellationToken cancellationToken);

        /// <summary>
        /// Изменение данных машины
        /// </summary>
        Task<Car> Edit(Guid ID, CarRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает список <see cref="Car"/>
        /// </summary>
        Task<IReadOnlyCollection<Car>> GetCars(CancellationToken cancellationToken);

        /// <summary>
        /// Получает автомобиль по id
        /// </summary>
        Task<Car?> GetCar(Guid id, CancellationToken cancellationToken);

        /// <summary>
            /// Возвращяет статистику <see cref="CarStatustic"/>
            /// </summary>
        Task<CarStatustic> GetStatistic(CancellationToken cancellationToken);
    }
}