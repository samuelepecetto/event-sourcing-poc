using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcing.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

}
