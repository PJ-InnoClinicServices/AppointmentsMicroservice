namespace BusinessLogicLayer.DTOs;

public record CreateAppointmentDto
{
    public Guid PatientId { get; set; }        
    public Guid DoctorId { get; set; }        
    public Guid PlaceId { get; set; }         
    public DateTime AppointmentDate { get; set; } 
}