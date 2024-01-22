using GaB_Core.ProtectedDbConnector.Models;
using Microsoft.EntityFrameworkCore;
namespace GaB_Core.ProtectedDbConnector;
public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GAB_Core.ConfigurationManager.ConnectionStringProtectedDb);
    }
}