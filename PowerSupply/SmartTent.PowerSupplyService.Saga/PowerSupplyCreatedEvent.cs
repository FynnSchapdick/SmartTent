namespace SmartTent.PowerSupplyService.Saga;

public interface PowerSupplyCreatedEvent
{
    string DeviceId { get; }
}