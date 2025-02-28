namespace DataAccessLayer.Interfaces;

public interface IRepository<in TCreateDto, in TUpdateDto, T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(TCreateDto entity);
    Task UpdateAsync(TUpdateDto entity);
    Task DeleteAsync(Guid id);
}