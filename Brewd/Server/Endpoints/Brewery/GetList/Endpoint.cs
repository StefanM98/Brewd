using Brewd.Shared.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Brewd.Server.Endpoints.Brewery.GetList;

[HttpGet("breweries")]
[AllowAnonymous]
public class Endpoint : Endpoint<Request, Response>
{
    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        await SendAsync(
            await Data.GetList(req));
    }
}