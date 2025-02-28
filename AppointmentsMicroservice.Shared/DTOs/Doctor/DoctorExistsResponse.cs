namespace Shared.DTOs.Doctor;

public record DoctorExistsResponse
{
    public bool Exists { get; init; }
}