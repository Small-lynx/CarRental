namespace CarRental.Storage.Contract
{
    /// <summary>
    /// Хранение всех сущностей <see cref="T"/>
    /// </summary>
    public interface IStorage<T>
    {
        /// <summary>
        /// Получает список всех сущностей <see cref="T"/>
        /// </summary>
        Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken);
        
        /// <summary>
        /// Получает сущность <see cref="T"/> по ID
        /// </summary>
        Task<T?> Get(Guid ID, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет сущность <see cref="T"/> в хранилище
        /// </summary>
        Task Add(T item, CancellationToken cancellationToken);
        
        /// <summary>
        /// Редактирует сущность <see cref="T"/> в хранилище
        /// </summary>
        Task Edit(Guid ID, T item, CancellationToken cancellationToken);
        
        /// <summary>
        /// Удаляет сущность <see cref="T"/> в хранилище
        /// </summary>
        Task Delete(Guid ID, CancellationToken cancellationToken);
    }
}
