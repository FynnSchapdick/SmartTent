using MassTransit;
using SmartTent.PowerSupply.Contracts.Messaging.Commands;
using SmartTent.PowerSupply.Contracts.Messaging.Responses;

namespace SmartTent.PowerSupply.StateMachines;

public sealed class PowerSupplyStateMachine : MassTransitStateMachine<PowerSupply>
{
    public State Disconnected { get; private set; }
    public Event<RegisterPowerSupply> RegisterPowerSupply { get; private set; }

    
    public PowerSupplyStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(
            () => RegisterPowerSupply, 
            cc => cc.CorrelateById(powerSupply => powerSupply.Message.PowerSupplyId)
        );

        Initially(
            When(RegisterPowerSupply)
                .Then(context =>
                {
                    context.Saga.Created = context.Message.Timestamp;
                    context.Saga.PowerSupplyId = context.Message.PowerSupplyId;
                    context.Saga.DeviceId = context.Message.DeviceId;
                })
                .TransitionTo(Disconnected)
                // .Respond(context => new PowerSupplyRegistrationAccepted(context.Saga.PowerSupplyId))
        );
    }
}