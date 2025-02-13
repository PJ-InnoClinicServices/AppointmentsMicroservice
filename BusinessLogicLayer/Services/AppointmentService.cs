using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.IServices;

namespace BusinessLogicLayer.Services;

public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
            if (appointment == null)
            {
                throw new Exception("Appointment not found.");
            }

            return appointment.ToDto();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsForPatientAsync(Guid patientId)
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsForPatientAsync(patientId);
            return appointments.Select(a => a.ToDto());
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsForDoctorAsync(Guid doctorId)
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsForDoctorAsync(doctorId);
            return appointments.Select(a => a.ToDto());
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPlaceAsync(Guid placeId)
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsByPlaceAsync(placeId);
            return appointments.Select(a => a.ToDto());
        }

        public async Task CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
        {
            await _unitOfWork.Appointments.CreateAsync(createAppointmentDto);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAppointmentAsync(UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(updateAppointmentDto.Id);
            if (appointment == null)
            {
                throw new Exception("Appointment not found.");
            }

            // Aktualizowanie wizyty
            appointment.PatientId = updateAppointmentDto.PatientId;
            appointment.DoctorId = updateAppointmentDto.DoctorId;
            appointment.PlaceId = updateAppointmentDto.PlaceId;
            appointment.AppointmentDate = updateAppointmentDto.AppointmentDate;
            appointment.Status = updateAppointmentDto.Status;

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAppointmentAsync(DeleteAppointmentDto deleteAppointmentDto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(deleteAppointmentDto.Id);
            if (appointment == null)
            {
                throw new Exception("Appointment not found.");
            }

            await _unitOfWork.Appointments.DeleteAsync(deleteAppointmentDto.Id);
            await _unitOfWork.SaveAsync();
        }
    }