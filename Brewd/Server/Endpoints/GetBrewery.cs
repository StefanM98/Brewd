using Brewd.Shared.Contracts;
using Brewd.Server.Data;
using Brewd.Server.Mappers;
using FastEndpoints;

namespace Brewd.Server.Endpoints;

public class GetBrewery : Endpoint<BreweryRequest, BreweryResponse, BreweryMapper>
{
    //public ILogger<GetBrewery> Logger { get; init; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("breweries/{BreweryID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(BreweryRequest req, CancellationToken ct)
    {
        //Logger.LogDebug("Retrieving brewery with BreweryID '{BreweryID}'", req.BreweryID);

        var context = new BreweryContext();

        var brewery = context.Breweries.Find(req.BreweryID);

        if (brewery is null)
        {
            await SendNotFoundAsync();
        }
        else
        {
            var response = Map.FromEntity(brewery);
            await SendAsync(response, cancellation: ct);
        }
    }
}