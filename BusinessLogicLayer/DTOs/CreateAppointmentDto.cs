namespace BusinessLogicLayer.DTOs;

public class CreateAppointmentDto
{
    public Guid PatientId { get; set; }        
    public Guid DoctorId { get; set; }        
    public Guid PlaceId { get; set; }         
    public DateTime AppointmentDate { get; set; } 
}