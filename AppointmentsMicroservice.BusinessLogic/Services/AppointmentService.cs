using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using MassTransit;
using Shared.DTOs.Appointment;
using Shared.DTOs.Doctor;

namespace BusinessLogicLayer.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository,
    IRequestClient<DoctorExistsRequest> client) : IAppointmentService
{
    public async Task<IEnumerable<AppointmentEntity>> GetAllAsync()
    {
        return await appointmentRepository.GetAllAsync();
    }
        
    public async Task<AppointmentEntity> GetByIdAsync(Guid id)
    {
        return await appointmentRepository.GetByIdAsync(id);
    }
        
    public async Task CreateAsync(CreateAppointmentDto dto)
    {
        var response = await client.GetResponse<DoctorExistsResponse>(new DoctorExistsRequest { DoctorId = dto.DoctorId });
        if (response.Message.Exists == false)
        {
            throw new ApplicationException("Doctor does not exist");
        }
        await appointmentRepository.CreateAsync(dto);
    }
        
    public async Task UpdateAsync(UpdateAppointmentDto dto)
    {
        await appointmentRepository.UpdateAsync(dto);
    }
        
    public async Task DeleteAsync(Guid id)
    {
        await appointmentRepository.DeleteAsync(id);
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