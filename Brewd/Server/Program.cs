using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using FastEndpoints.Swagger;
using Brewd.Server.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");

// Add services
builder.Services.AddDbContext<BreweryContext>(
        options => options.UseSqlServer(connectionString));

builder.Services.AddFastEndpoints(o =>
{
    o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerDoc(addJWTBearerAuth: false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

// Configure client hosting
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();

// Configure FastEndpoints
app.UseFastEndpoints(c =>
{
    c.RoutingOptions = o => o.Prefix = "api";
});

// Configure Swagger
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.MapFallbackToFile("index.html");

app.Run();