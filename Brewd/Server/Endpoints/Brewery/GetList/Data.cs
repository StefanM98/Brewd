using Brewd.Server.Data;
using Brewd.Shared.Models;

namespace Brewd.Server.Endpoints.Brewery.GetList;

public static class Data
{
    internal static Task<Response> GetList(Request req)
    {
        var context = new BreweryContext();
        var res = context.Breweries.Where(b => b.City == req.ByCity).AsEnumerable().Take(20);

        return Task.FromResult((Response)res);
    }
}
