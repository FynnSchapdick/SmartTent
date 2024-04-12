using MassTransit;

namespace SmartTent.PowerSupplyService.Saga;

public sealed class PowerSupplyStateMachine : MassTransitStateMachine<PowerSupplyState>
{
    public State Off { get; private set; }
    
    public Event<PowerSupplyCreatedEvent> PowerSupplyCreatedEvent { get; private set; }
    
    public PowerSupplyStateMachine()
    {
        Event(() => PowerSupplyCreatedEvent, configurator => configurator.CorrelateById( c => c.CorrelationId.Ha));
        
        Initially(
            When(PowerSupplyCreatedEvent).Then(x =>
                {
                    this.Pow
                })
                .TransitionTo(Off));

    }
}