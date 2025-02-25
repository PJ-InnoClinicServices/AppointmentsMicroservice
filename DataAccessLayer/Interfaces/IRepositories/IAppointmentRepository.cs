using DataAccessLayer.Entities;
using Shared.DTOs.Appointment;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IAppointmentRepository : IRepository<CreateAppointmentDto, UpdateAppointmentDto, AppointmentEntity>
    {
        Task<IEnumerable<AppointmentEntity>> GetAppointmentsForPatientAsync(Guid patientId);
        Task<IEnumerable<AppointmentEntity>> GetAppointmentsForDoctorAsync(Guid doctorId);
        Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceAsync(Guid patientId);
    }
}
