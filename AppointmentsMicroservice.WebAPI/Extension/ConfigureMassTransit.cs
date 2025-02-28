using MassTransit;
namespace PresentationLayer.Extension;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
    {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });
        return services;
    }
}
   
