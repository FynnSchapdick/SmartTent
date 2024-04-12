namespace SmartTent.PowerSupply.Contracts.Messaging.Abstractions;

public interface IPowerSupplyRegisteredEvent
{
    Guid CorrelationId { get; }
    DateTime Timestamp { get; }
    Guid PowerSupplyId { get; }
    string DeviceId { get; }
}