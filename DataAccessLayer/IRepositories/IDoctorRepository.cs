using DataAccessLayer.Entities;

namespace DataAccessLayer.IRepositories;
    public interface IDoctorRepository
    {
        Task<Doctor> GetByIdAsync(Guid id);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty);
        Task CreateAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
    }
