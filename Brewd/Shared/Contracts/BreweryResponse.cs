using Brewd.Shared.Models;

namespace Brewd.Shared.Contracts
{
    public class BreweryResponse
    {
        public string ID { get; set; }
        public string Name { get; set; }
        
        public TypeOfBrewery? BreweryType { get; set; }
        
        public string Street { get; set; }
 
        public string? Address2 { get; set; }
        
        public string? Address3 { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
       
        public string? CountyProvince { get; set; }
        
        public string PostalCode { get; set; }
        
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string? Phone { get; set; }
        public string? WebsiteURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
