namespace BusinessLogicLayer.Interfaces
{
    public interface IService<TCreateDto, TUpdateDto, TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}