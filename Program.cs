using FirstCrudApp.Data;
using FirstCrudApp.EndPoints;


var builder = WebApplication.CreateBuilder(args);

// Data/DataExtension, AddRepositories ==> to inject repositories as dependencies in the app
builder.Services.AddRepositories(builder.Configuration);


// build the application
var app = builder.Build();

// data/ DataExtension ==> used for automatic db migration whenever the application starts up
await app.Services.InitializeDbAsync();


// Add mappings and routings
app.MapGet("/", () => "Hello World!");
app.GameRouteController();


// Running the application
app.Run();
