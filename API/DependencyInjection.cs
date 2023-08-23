using EventSourcing.API.Configuration;
using TinyFp.Extensions;

namespace EventSourcing.API;
internal static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this WebApplicationBuilder builder) =>
        builder.Services.Configure<EventStoreOptions>(
            builder.Configuration.GetSection(EventStoreOptions.SectionName));

    public static IServiceCollection AddEventStore(this WebApplicationBuilder builder)
    {
        EventStoreOptions options = new();
        builder.Configuration
            .GetSection(EventStoreOptions.SectionName)
            .Bind(options);
        return builder.Services.Tee(s => s
            .AddEventStoreClient(options.ConnectionString)
            .AddHealthChecks()
            .AddEventStore(options.ConnectionString));
    }

}
