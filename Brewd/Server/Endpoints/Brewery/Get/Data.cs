using Brewd.Server.Data;

namespace Brewd.Server.Endpoints.Brewery.Get;

public static class Data
{
    internal static Task<Response> Get(string breweryId)
    {
        var context = new BreweryContext();
        var res = context.Breweries.FirstOrDefault(b => b.BreweryID == breweryId);

        if (res == null)
        {
            return Task.FromResult<Response>(null);
        }
        
        var response = new Response
        {
            ID = res.BreweryID,
            Name = res.Name,
            BreweryType = res.BreweryType,
            Street = res.Street,
            Address2 = res.Address2,
            Address3 = res.Address3,
            City = res.City,
            State = res.State,
            CountyProvince = res.CountyProvince,
            PostalCode = res.PostalCode,
            Country = res.Country,
            Longitude = res.Longitude,
            Phone = res.Phone,
            WebsiteURL = res.WebsiteURL,
            CreatedAt = res.CreatedAt,
            UpdatedAt = res.UpdatedAt
        };

        return Task.FromResult(response);
    }
}
