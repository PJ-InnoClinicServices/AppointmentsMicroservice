using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;

namespace DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Patients = new PatientRepository(context);
        Doctors = new DoctorRepository(context);
        Appointments = new AppointmentRepository(context);
    }

    public IPatientRepository Patients { get; private set; }
    public IDoctorRepository Doctors { get; private set; }
    public IAppointmentRepository Appointments { get; private set; }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

