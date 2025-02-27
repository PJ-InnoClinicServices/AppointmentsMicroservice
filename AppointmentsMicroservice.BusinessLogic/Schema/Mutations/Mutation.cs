using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using Shared.DTOs.Appointment;
using DataAccessLayer.Enums;

namespace BusinessLogicLayer.Schema.Mutations
{
    public class Mutation
    {
        private readonly AppointmentService _appointmentService;

        public Mutation(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        public async Task<AppointmentEntity> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            await _appointmentService.CreateAsync(dto);
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
            await _appointmentService.UpdateAsync(dto);
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
            await _appointmentService.DeleteAsync(id);
            return true; 
        }
    }
}