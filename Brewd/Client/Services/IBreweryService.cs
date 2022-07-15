using Brewd.Shared.Contracts;
using Brewd.Shared.Models;

namespace Brewd.Client.Services;

public interface IBreweryService
{
    Task<IEnumerable<Brewery>> GetBreweries(BreweriesRequest? req);
    Task<Brewery> GetBrewery(string Id);
    Task<IEnumerable<Brewery>> Search(string query);
    Task<Brewery> GetRandomBrewery();
    
}
