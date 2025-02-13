using DataAccessLayer.Entities;

namespace DataAccessLayer.IRepositories;

    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(Guid id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task CreateAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    
}