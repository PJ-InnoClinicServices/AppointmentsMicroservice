namespace DataAccessLayer.Interfaces;

public interface IRepository<CreateDto, UpdateDto, T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(CreateDto entity);
    Task UpdateAsync(UpdateDto entity);
    Task DeleteAsync(Guid id);
}