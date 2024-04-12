using MassTransit;

namespace SmartTent.PowerSupply.StateMachines;

public sealed class PowerSupplyStateDefinition : SagaDefinition<PowerSupply>
{
    protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<PowerSupply> sagaConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 1000));
        endpointConfigurator.UseInMemoryOutbox(context);
    }
}