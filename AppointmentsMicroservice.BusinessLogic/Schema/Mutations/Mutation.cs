using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using Shared.DTOs.Appointment;
using DataAccessLayer.Enums;

namespace BusinessLogicLayer.Schema.Mutations;

public class Mutation(IAppointmentService appointmentService)
{
    public async Task<AppointmentEntity> CreateAppointmentAsync(CreateAppointmentDto dto)
    {
        await appointmentService.CreateAsync(dto);
        return new AppointmentEntity
        {
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            AppointmentDate = dto.AppointmentDate,
            Reason = dto.Reason,  
            Status = AppointmentStatus.Pending 
        };
    }
        
    public async Task<AppointmentEntity> UpdateAppointmentAsync(UpdateAppointmentDto dto)
    {
        await appointmentService.UpdateAsync(dto);
        return new AppointmentEntity
        {
            Id = dto.Id,
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            AppointmentDate = dto.AppointmentDate,
            Reason = dto.Reason,
            Status = dto.Status
        };
    }
        
    public async Task<bool> DeleteAppointmentAsync(Guid id)
    {
        await appointmentService.DeleteAsync(id);
        return true; 
    }
}