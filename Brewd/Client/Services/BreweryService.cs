using System.Net.Http.Json;
using System.Web;
using Brewd.Shared.Contracts;
using Brewd.Shared.Models;

namespace Brewd.Client.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly HttpClient _http;
        private readonly string host = "api.openbrewerydb.orgs";
        
        public BreweryService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        

        public async Task<IEnumerable<Brewery>> GetBreweries(BreweriesRequest? req)
        {
            var uriBuilder = new UriBuilder($"{host}/breweries");
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            
            parameters["by-city"] = req?.ByCity;
            
            uriBuilder.Query = parameters.ToString();

            IEnumerable<Brewery>? breweries = await _http.GetFromJsonAsync<IEnumerable<Brewery>>(uriBuilder.Uri);
            
            if (breweries is null)
            {
                breweries = new List<Brewery>();
            }

            return breweries;
        }

        public async Task<Brewery> GetBrewery(string Id)
        {
            return await _http.GetFromJsonAsync<Brewery>($"{host}/breweries/{Id}");
        }

        public async Task<Brewery> GetRandomBrewery()
        {
            return await _http.GetFromJsonAsync<Brewery>($"{host}/breweries/random");
        }

        public async Task<IEnumerable<Brewery>> Search(string query)
        {
            var uriBuilder = new UriBuilder($"{host}/breweries/search");
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters["query"] = query;

            uriBuilder.Query = parameters.ToString();

            IEnumerable<Brewery>? breweries = await _http.GetFromJsonAsync<IEnumerable<Brewery>>(uriBuilder.Uri);

            if (breweries is null)
            {
                breweries = new List<Brewery>();
            }

            return breweries;
        }
    }
}
