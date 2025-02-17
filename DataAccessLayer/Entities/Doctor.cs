using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Entities;

public class Doctor : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}