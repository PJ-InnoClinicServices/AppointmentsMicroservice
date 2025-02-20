
using DataAccessLayer.Enums;

namespace Shared.DTOs.Appointment;

public record UpdateAppointmentDto
{
    public Guid Id { get; set; }             
    public Guid PatientId { get; set; }   
    public Guid DoctorId { get; set; }       
    
    public string Reason { get; set; }
    public Guid Place { get; set; }      
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }         
}