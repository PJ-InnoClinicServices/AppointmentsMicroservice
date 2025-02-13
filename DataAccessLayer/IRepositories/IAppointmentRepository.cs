using DataAccessLayer.Entities;

namespace DataAccessLayer.IRepositories;

public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(Guid patientId);
    Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId);
    Task CreateAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Guid id);
}