namespace Shared.DTOs.Doctor;

public record DoctorExistsRequest
{
    public Guid DoctorId { get; init; }
}