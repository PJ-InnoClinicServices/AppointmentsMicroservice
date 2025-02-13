namespace BusinessLogicLayer.DTOs;

public class AppointmentDto
{
    public Guid Id { get; set; }              // Id wizyty
    public Guid PatientId { get; set; }        // Id pacjenta
    public string PatientName { get; set; }    // Imię pacjenta
    public Guid DoctorId { get; set; }         // Id lekarza
    public string DoctorName { get; set; }     // Imię lekarza
    public Guid PlaceId { get; set; }          // Id miejsca
    public string PlaceName { get; set; }      // Nazwa miejsca
    public DateTime AppointmentDate { get; set; } // Data i godzina wizyty
    public string Status { get; set; }         // Status wizyty (np. "Scheduled", "Completed")
}