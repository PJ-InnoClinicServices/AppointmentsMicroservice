using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities;

public record AppointmentEntity
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
  
    public string Reason { get; set; }
    
    public AppointmentStatus Status { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PlaceId { get; set; } 
}