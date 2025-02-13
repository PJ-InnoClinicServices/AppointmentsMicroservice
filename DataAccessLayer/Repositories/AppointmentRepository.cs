using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Pobierz wizytę po Id
        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .Include(a => a.Patient)  
                .Include(a => a.Doctor)   
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Pobierz wizyty dla konkretnego pacjenta
        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(Guid patientId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        // Pobierz wizyty dla konkretnego lekarza
        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(Guid doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }



        // Dodaj nową wizytę
        public async Task CreateAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        // Zaktualizuj wizytę
        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }


        // Usuń wizytę
        public async Task DeleteAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
