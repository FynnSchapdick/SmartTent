using System.Net.Mime;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SmartTent.PowerSupply.Api.Extensions;
using SmartTent.PowerSupply.Contracts.Messaging.Abstractions;
using SmartTent.PowerSupply.Contracts.Messaging.Commands;
using SmartTent.PowerSupply.Contracts.Messaging.Responses;
using SmartTent.PowerSupply.Contracts.Rest.Requests;

namespace SmartTent.PowerSupply.Api.Endpoints;

public sealed class RegisterPowerSupplyEndpoint : IEndpoint
{
    public sealed record RegisterPowerSupplyParameters(
        [FromBody] RegisterPowerSupplyRequest Body
    );
    
    public static string EndpointName => "RegisterPowerSupply";
    
    public static RouteHandlerBuilder ConfigureEndpoint(IEndpointRouteBuilder builder, string route) =>
        builder.MapPost(route, HandleRegisterPowerSupply)
        .Accepts<RegisterPowerSupplyRequest>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status202Accepted)
        .ProducesInternalServerError();

    private static async Task<IResult> HandleRegisterPowerSupply(
        [AsParameters] RegisterPowerSupplyParameters parameters,
        [FromServices] IRequestClient<IRegisterPowerSupplyCommand> client,
        CancellationToken cancellationToken
    )
    {
        await client.GetResponse<PowerSupplyRegistrationAccepted>(new RegisterPowerSupply(Guid.NewGuid(), DateTime.Now, parameters.Body.DeviceId), cancellationToken: cancellationToken);

        return Results.AcceptedAtRoute();
    }
}