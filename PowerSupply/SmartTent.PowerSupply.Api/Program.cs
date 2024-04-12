using MassTransit;
using SmartTent.PowerSupply.Api.Endpoints;
using SmartTent.PowerSupply.Api.Extensions;
using SmartTent.PowerSupply.StateMachines;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(configure =>
{
    configure.AddSagaStateMachine<PowerSupplyStateMachine, PowerSupply, PowerSupplyStateDefinition>()
        .RedisRepository(builder.Configuration.GetConnectionString("Redis"));
    
    configure.UsingRabbitMq((context,cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        cfg.ConfigureEndpoints(context);
    });
});

WebApplication app = builder.Build();

RouteGroupBuilder powerSupply = app.MapGroup("/api").MapGroup("/powersupply").WithTags("PowerSupply");

powerSupply.Map<RegisterPowerSupplyEndpoint>("/register");

await app.RunAsync();

public partial class Program { }