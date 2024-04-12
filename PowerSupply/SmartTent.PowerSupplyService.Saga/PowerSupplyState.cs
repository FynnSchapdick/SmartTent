using MassTransit;

namespace SmartTent.PowerSupplyService.Saga;

public sealed class PowerSupplyState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string DeviceId { get; set; }
    public string CurrentState { get; set; }
}