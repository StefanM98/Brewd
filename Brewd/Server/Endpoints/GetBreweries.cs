using Brewd.Server.Data;
using Brewd.Server.Mappers;
using Brewd.Shared.Contracts;
using FastEndpoints;

namespace Brewd.Server.Endpoints;

public class GetBreweries : Endpoint<BreweriesRequest, BreweriesResponse, BreweriesMapper>
{
    public ILogger<GetBreweries> Logger { get; init; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("breweries");
        AllowAnonymous();
    }

    public override Task HandleAsync(BreweriesRequest req, CancellationToken ct)
    {
        var breweries = Map.ToEntity(req);
        Response = Map.FromEntity(breweries);
        
        return Task.CompletedTask;
    }
}
