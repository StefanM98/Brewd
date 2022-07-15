using System.ComponentModel.DataAnnotations;

namespace Brewd.Shared.Models;

public enum TypeOfBrewery
{
    micro, nano, regional, brewpub, large, planning, bar, contract, proprietor, closed
}

public class Brewery
{
    public string BreweryID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public TypeOfBrewery BreweryType { get; set; }
    [Required]
    public string Street { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    [Required]
    public string City { get; set; }
    public string State { get; set; }
    public string CountyProvince { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string Country { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
    public string Phone { get; set; }
    public string WebsiteURL { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // public IEnumerable<string> Tags { get; set; }
}
