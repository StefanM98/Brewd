using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Brewd.Server.Endpoints.Brewery.Get;

[HttpGet("breweries/{obdb-id}")]
[AllowAnonymous]
public class Endpoint : Endpoint<Request, Response>
{
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        await SendAsync(
            await Data.Get(req.BreweryID));
    }
}