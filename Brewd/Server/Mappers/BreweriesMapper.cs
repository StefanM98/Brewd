using Brewd.Server.Data;
using Brewd.Shared.Contracts;
using Brewd.Shared.Models;
using FastEndpoints;

namespace Brewd.Server.Mappers
{
    public class BreweriesMapper : Mapper<BreweriesRequest, BreweriesResponse, List<Brewery>>
    {
        
    
        public override List<Brewery> ToEntity(BreweriesRequest request)
        {
            var context = new BreweryContext();
             
            var data = context.Breweries;

            // TODO: Filter logic here

            return data.ToList();
        }
    }
}
