using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
 public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
 {
     public DbSet<AppointmentEntity> Appointments { get; set; }

        
    }
}