using FastEndpoints;
using Brewd.Shared.Contracts;

namespace Brewd.Server.Endpoints.Brewery.Get;

public class Request 
{
    [BindFrom("obdb-id")]
    public string BreweryID { get; set; }
}

public class Response : BreweryResponse { }
