using FirstCrudApp.Controller;
using FirstCrudApp.Data;
using FirstCrudApp.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Repositories => used to register servies under repositories to the application itself
builder.Services.AddSingleton<IGameRepository, InDbGameRepository>();

// Data/GameStoreContext ==> used to connect to the database
var ConnString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(ConnString);


// build the application
var app = builder.Build();

// data/ DataExtension ==> used for automatic db migration whenever the application starts up

app.Services.InitializeDb();


// Add mappings and routings
app.MapGet("/", () => "Hello World!");
app.GameRouteController();


// Running the application
app.Run();
