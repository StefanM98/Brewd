using Brewd_API.Contracts.Models;

namespace Public.GetBreweryList
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {
        private static readonly Brewery[] breweries =
        {
            new Brewery
            (
                1, "Colonial Bar & Grill", "Grill", "14130 Pennsylvania Ave", null, null, "Hagerstown", "MD", null, "21742", "United States", "39.702052", "-77.722484", "+13017390667", "http://www.colonialbargrill.com/"
            ),
            new Brewery
            (
                1, "Colonial Bar & Grill", "Grill", "14130 Pennsylvania Ave", null, null, "Hagerstown", "MD", null, "21742", "United States", "39.702052", "-77.722484", "+13017390667", "http://www.colonialbargrill.com/"
            )
        };

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("breweries");
            AllowAnonymous();
        }

        public override Task HandleAsync(Request r, CancellationToken c)
        {
            return SendAsync(Response);
        }
    }
}