using Brewd.Shared.Models;

namespace Brewd.Shared.Contracts;

public class BreweriesResponse : List<BreweryResponse> 
{
    public BreweriesResponse()
    {
        new List<BreweryResponse>();
    }
}