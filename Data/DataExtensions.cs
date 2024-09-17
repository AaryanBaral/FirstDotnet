
using FirstCrudApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudApp.Data;

public static class DataExtensions
{
    public async  static Task InitializeDbAsync (this IServiceProvider serviceProvider){
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();

    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    ){
        // Data/GameStoreContext ==> used to connect to the database
        // Repositories => used to register servies under repositories to the application itself
        var ConnString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(ConnString)
        .AddScoped<IGameRepository, InDbGameRepository>();
         return services;
    }
}