using DataAccessLayer.Entities;
using Shared.DTOs.Appointment;

namespace BusinessLogicLayer.Interfaces.IServices;

public interface IAppointmentService : IService<CreateAppointmentDto, UpdateAppointmentDto, AppointmentEntity>
{
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsForPatientAsync(Guid patientId);
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsForDoctorAsync(Guid doctorId);
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceAsync(Guid placeId);
     
}