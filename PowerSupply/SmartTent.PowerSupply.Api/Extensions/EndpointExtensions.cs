using JetBrains.Annotations;
using SmartTent.PowerSupply.Api.Endpoints;

namespace SmartTent.PowerSupply.Api.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder Map<TEndpoint>(this IEndpointRouteBuilder builder, [RouteTemplate] string route = "/") where TEndpoint : IEndpoint
    {
        TEndpoint.ConfigureEndpoint(builder, route)
            .WithName(TEndpoint.EndpointName);

        return builder;
    }

    public static RouteHandlerBuilder ProducesInternalServerError(this RouteHandlerBuilder builder) =>
        builder.ProducesProblem(StatusCodes.Status500InternalServerError);
}
