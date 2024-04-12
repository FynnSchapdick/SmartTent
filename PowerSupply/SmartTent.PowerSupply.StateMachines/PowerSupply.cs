using MassTransit;

namespace SmartTent.PowerSupply.StateMachines;

public sealed class PowerSupply : SagaStateMachineInstance, ISagaVersion
{
    public Guid CorrelationId { get; set; }
    
    public State CurrentState { get; set; } = null!;

    public DateTime Created { get; set; }
    
    public Guid PowerSupplyId { get; set; }
    
    public string DeviceId { get; set; } = null!;
    
    public int Version { get; set; }
}