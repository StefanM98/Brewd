namespace Brewd.Server.Data;
public static class DbInitializer
{
    public static void Initialize(BreweryContext context)
    {
        // If there are any breweries, the DB has already been seeded.
        if (context.Breweries.Any()) return;


        // TODO: Retrieve breweries from openbrewerydb/openbrewerydb


        // TODO: Save Breweries
        // context.Breweries.AddRange(data);
        // context.SaveChanges();
        return;
    }
}