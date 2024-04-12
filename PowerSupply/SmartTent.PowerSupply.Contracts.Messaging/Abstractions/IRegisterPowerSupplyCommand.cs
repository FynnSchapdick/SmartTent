namespace SmartTent.PowerSupply.Contracts.Messaging.Abstractions;

public interface IRegisterPowerSupplyCommand
{
    Guid PowerSupplyId { get; }
    DateTime Timestamp { get; }
    string DeviceId { get; }
}