using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.DTOs.Appointment;
using Shared.DTOs.Doctor;

namespace DataAccessLayer.Repositories;

public class AppointmentRepository(IDbContextFactory<ApplicationDbContext> contextFactory, 
    ISendEndpointProvider sendEndpointProvider,
    IRequestClient<DoctorExistsResponse> client
) : IAppointmentRepository
{
    public async Task<AppointmentEntity> GetByIdAsync(Guid id)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Appointments
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAllAsync()
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Appointments
            .ToListAsync();

    }
        
    public async Task CreateAsync(CreateAppointmentDto entity)
    {
        using var context = contextFactory.CreateDbContext();
                 
        var appointment = new AppointmentEntity
        {
            AppointmentDate = entity.AppointmentDate,
            Status = entity.Status,
            Reason = entity.Reason,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            PlaceId = entity.PlaceId,
                 
        };
                 
        await context.Appointments.AddAsync(appointment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateAppointmentDto entity)
    {
        using var context = contextFactory.CreateDbContext();

        var appointment = await context.Appointments.FindAsync(entity.Id);
        if (appointment != null)
        {
            appointment.PatientId = entity.PatientId;
            appointment.DoctorId = entity.DoctorId;
            appointment.AppointmentDate = entity.AppointmentDate;
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        using var context = contextFactory.CreateDbContext();
        var appointment = await context.Appointments.FindAsync(id);
        if (appointment != null)
        {
            context.Appointments.Remove(appointment);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsForPatientAsync(Guid patientId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Appointments
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsForDoctorAsync(Guid doctorId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Appointments
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceAsync(Guid patientId)
    {
        using var context = contextFactory.CreateDbContext();

        return await context.Appointments
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }
}