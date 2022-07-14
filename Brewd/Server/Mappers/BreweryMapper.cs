using Brewd.Shared.Contracts;
using Brewd.Shared.Models;
using FastEndpoints;

namespace Brewd.Server.Mappers;

public class BreweryMapper : Mapper<BreweryRequest, BreweryResponse, Brewery>
{
    public override BreweryResponse FromEntity(Brewery e)
    {
        return new BreweryResponse
        {
            ID = e.BreweryID,
            Name = e.Name,
            BreweryType = e.BreweryType,
            Street = e.Street,
            Address2 = e.Address2,
            Address3 = e.Address3,
            City = e.City,
            State = e.State,
            CountyProvince = e.CountyProvince,
            PostalCode = e.PostalCode,
            Country = e.Country,
            Longitude = e.Longitude,
            Latitude = e.Latitude,
            Phone = e.Phone,
            WebsiteURL = e.WebsiteURL,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        };
    }
}