namespace Brewd_API.Contracts.Models
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BreweryType { get; set; }
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

        public Brewery(int id, string name, string breweryType, string street, string? address2, string? address3, string city, string state, string? countyProvince, string postalCode, string country, string longitude, string latitude, string? phone, string? websiteURL)
        {
            Id = id;
            Name = name;
            BreweryType = breweryType;
            Street = street;
            Address2 = address2;
            Address3 = address3;
            City = city;
            State = state;
            CountyProvince = countyProvince;
            PostalCode = postalCode;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
            Phone = phone;
            WebsiteURL = websiteURL;
        }
    }
}
