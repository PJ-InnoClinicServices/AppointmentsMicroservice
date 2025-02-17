namespace BusinessLogicLayer.DTOs;

public record AppointmentDto
{
    public Guid Id { get; set; }           
    public Guid PatientId { get; set; }      
    public string PatientName { get; set; }    
    public Guid DoctorId { get; set; }         
    public string DoctorName { get; set; }    
    public Guid PlaceId { get; set; }     
    public string PlaceName { get; set; }     
    public DateTime AppointmentDate { get; set; } 
    public string Status { get; set; }         
}