using DataAccessLayer.Enums;

namespace Shared.DTOs.Appointment
{
    public record AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public AppointmentStatus Status { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public Guid PlaceId { get; set; }
        public string PlaceName { get; set; }
    }
}