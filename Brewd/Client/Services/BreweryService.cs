using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Web;
using Brewd.Shared.Contracts;
using Brewd.Shared.Models;

namespace Brewd.Client.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly HttpClient _httpClient;

        private Uri GetUri(string path, string? query)
        {
            var reqBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = path,
                Query = query
            };

            return reqBuilder.Uri;

        }

        public BreweryService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }
        
        public async Task<IEnumerable<BreweryModel>> GetBreweries(BreweriesRequest? req)
        {
            if (req == null) throw new ArgumentNullException(nameof(req));

            // Parse query parameters
            NameValueCollection parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["by_city"] = req?.ByCity;
            parameters["by_postal"] = req?.ByPostal;
            parameters["per_page"] = req?.PerPage?.ToString();
            parameters["page"] = req?.Page?.ToString();
            parameters["by_type"] = req?.ByType.ToString();

            var uri = GetUri("/api/breweries", parameters.ToString());
           
            IEnumerable<BreweryResponse>? breweries = await _httpClient
                .GetFromJsonAsync<IEnumerable<BreweryResponse>>(uri);

            var result = new List<BreweryModel>();
            
            foreach (BreweryResponse response in breweries)
            {
                var entity = ToEntity(response);
                if (entity is not null) result.Add(entity);
            }

            return result;
        }

        public async Task<BreweryModel?> GetBrewery(string Id)
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));
            var uri = GetUri($"/api/breweries/{Id}", null);
            var res = await _httpClient.GetFromJsonAsync<BreweryResponse>(uri);
            return ToEntity(res);
        }

        public async Task<BreweryModel?> GetRandomBrewery()
        {
            var uri = GetUri($"/api/breweries/random", null);
            var res = await _httpClient.GetFromJsonAsync<BreweryResponse>(uri);
            return ToEntity(res);
        }

        public async Task<IEnumerable<BreweryModel?>> Search(string query)
        {
            // Parse query parameters
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["query"] = query;

            var uri = GetUri($"/api/breweries/search", parameters.ToString());

            IEnumerable<BreweryModel>? breweries = await _httpClient
                .GetFromJsonAsync<IEnumerable<BreweryModel>>(uri);

            if (breweries is null)
            {
                breweries = new List<BreweryModel>();
            }

            return breweries;
        }
        
        static BreweryModel ToEntity(BreweryResponse response)
        {
            return new BreweryModel
            {
                BreweryID = response.ID,
                Name = response.Name,
                Street = response.Street,
                Address2 = response.Address2,
                Address3 = response.Address3,
                City = response.City,
                PostalCode = response.PostalCode,
                BreweryType = Enum.Parse<TypeOfBrewery>(response.BreweryType.ToString()),
                WebsiteURL = response.WebsiteURL,
                Phone = response.Phone,
                CreatedAt = response.CreatedAt,
                UpdatedAt = response.UpdatedAt
            };
        }
    }
}
