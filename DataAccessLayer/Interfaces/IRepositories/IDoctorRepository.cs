using DataAccessLayer.Entities;
namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty);
    }
}
