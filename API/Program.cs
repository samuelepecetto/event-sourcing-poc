using EventSourcing.Api.Routing;
using EventSourcing.API;
using EventSourcing.Application;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TinyFp.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder
    .Tee(_ => _.AddConfiguration())
    .Tee(_ => _.AddEventStore())
    .Services
    .AddEndpointsApiExplorer()
    .AddApplicationServices()
    .AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .Tee(_ => _.MapECommerceEndpoints())
    .Tee(_ => _.UseHttpsRedirection())
    .Tee(_ => _.MapHealthChecks("/healthz", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }))
    ;

app.Run();

