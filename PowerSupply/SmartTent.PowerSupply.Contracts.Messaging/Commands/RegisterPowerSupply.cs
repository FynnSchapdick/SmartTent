using SmartTent.PowerSupply.Contracts.Messaging.Abstractions;

namespace SmartTent.PowerSupply.Contracts.Messaging.Commands;

public record RegisterPowerSupply(
    Guid PowerSupplyId,
    DateTime Timestamp,
    string DeviceId
) : IRegisterPowerSupplyCommand;