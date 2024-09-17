
using System.Reflection;
using FirstCrudApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudApp.Data;
public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {
    }
    public DbSet<Game> Games { get; set; }  //represents a Table in the Datase;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
