using Brewd.Shared.Contracts;
using Brewd.Shared.Models;

namespace Brewd.Client.Services;

public interface IBreweryService
{
    Task<IEnumerable<BreweryModel>> GetBreweries(BreweriesRequest? req);
    Task<BreweryModel?> GetBrewery(string Id);
    Task<IEnumerable<BreweryModel?>> Search(string query);
    Task<BreweryModel?> GetRandomBrewery();
    
}
