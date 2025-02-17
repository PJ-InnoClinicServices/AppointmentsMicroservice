namespace BusinessLogicLayer.DTOs;

public record UpdateAppointmentDto
{
    public Guid Id { get; set; }             
    public Guid PatientId { get; set; }   
    public Guid DoctorId { get; set; }       
    public Guid PlaceId { get; set; }          
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }         
}