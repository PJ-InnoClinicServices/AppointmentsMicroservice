using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(Guid patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId);
    }
}
