using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;

namespace BusinessLogicLayer.Schema.Queries;

public class Query(IAppointmentRepository appointmentRepository)
{
    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsAsync()
    {
        return await appointmentRepository.GetAllAsync();
    }
        
    public async Task<AppointmentEntity> GetAppointmentByIdAsync(Guid id)
    {
        return await appointmentRepository.GetByIdAsync(id);
    }
        
    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsForPatientAsync(Guid patientId)
    {
        return await appointmentRepository.GetAppointmentsForPatientAsync(patientId);
    }
        
    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsForDoctorAsync(Guid doctorId)
    {
        return await appointmentRepository.GetAppointmentsForDoctorAsync(doctorId);
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceAsync(Guid placeId)
    {
        return await appointmentRepository.GetAppointmentsByPlaceAsync(placeId);
    }
}