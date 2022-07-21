using Brewd.Server.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Azure.Identity;

// Setup web app builder
var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("SecretsUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

var connectionString = builder.Configuration.GetConnectionString("AppDb");

// Builder development services
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
} 
else
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        options.HttpsPort = 443;
    });
}

// Application services
builder.Services.AddDbContext<BreweryContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerDoc(addJWTBearerAuth: false);

builder.Services.AddFastEndpoints(o =>
{
    o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Environment-specific configuration
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Error");
}

// Initialize Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BreweryContext>();
    
    context.Database.EnsureCreated();

    DbInitializer.Initialize(context);
}

// Application configuration 
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.UseAuthorization();

// Configure FastEndpoints
app.UseFastEndpoints(c =>
{
    c.RoutingOptions = o => o.Prefix = "api";
});

// Configure Swagger
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

// Fallback
app.MapFallbackToFile("index.html");

app.Run();