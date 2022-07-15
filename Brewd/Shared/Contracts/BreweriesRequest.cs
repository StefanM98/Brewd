using Brewd.Shared.Models;

namespace Brewd.Shared.Contracts;



public class BreweriesRequest
{
    private enum SortOrder
    {
        asc,
        desc
    }

    public int? Page { get; set; }

    public int? PerPage { get; set; } 

    public string? SortBy { get; set; }

    public string? ByCity { get; set; }

    public string? ByState { get; set; }
    
    public string? ByName { get; set; }

    public string? ByPostal { get; set; }

    public TypeOfBrewery? ByType { get; set; }
}
