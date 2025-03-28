using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.AppExtensions;

public static class AddValidation
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateAppointmentValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateAppointmentValidator>();
    }
}