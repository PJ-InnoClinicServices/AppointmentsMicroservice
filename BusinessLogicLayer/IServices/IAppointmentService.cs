using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.IServices
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetAppointmentByIdAsync(Guid appointmentId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsForPatientAsync(Guid patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsForDoctorAsync(Guid doctorId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPlaceAsync(Guid placeId);
        Task CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto);
        Task UpdateAppointmentAsync(UpdateAppointmentDto updateAppointmentDto);
        Task DeleteAppointmentAsync(DeleteAppointmentDto deleteAppointmentDto);
    }
}
