using DataAccessLayer.Interfaces;
using Shared.Enums;

namespace DataAccessLayer.Entities;

public class Appointment : IEntity
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; }
    public AppointmentStatus Status { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}