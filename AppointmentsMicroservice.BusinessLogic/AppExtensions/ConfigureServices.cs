using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.AppExtensions;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentService, AppointmentService>();
    }
}