/*using Brewd.Server.Data;
using Brewd.Shared.Contracts;
using Brewd.Shared.Models;
using FastEndpoints;
using System.Linq;

namespace Brewd.Server.Endpoints.Brewery.GetList
{
    public class Mapper : Mapper<Request, Response, BreweryList>
    {

        public override BreweryList MapToEntity(Request request)
        {
            var context = new BreweryContext();

            var data = context.Breweries.();




            // TODO: Filter logic here


            return data.ToList<BreweryList>();
        }
    }
}
*/