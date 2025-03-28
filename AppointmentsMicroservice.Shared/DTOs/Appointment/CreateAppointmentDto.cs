using DataAccessLayer.Enums;

namespace Shared.DTOs.Appointment;

public record CreateAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; }
    public AppointmentStatus Status { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PlaceId { get; set; }
}