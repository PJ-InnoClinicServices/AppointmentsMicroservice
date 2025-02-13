using DataAccessLayer.IRepositories;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        IDoctorRepository Doctors { get; }
        IAppointmentRepository Appointments { get; }
        Task<int> SaveAsync();
    }
    
}