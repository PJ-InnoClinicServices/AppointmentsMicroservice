using DataAccessLayer;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.AppExtensions;

public static class ConfigureRepositories
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
    }
}