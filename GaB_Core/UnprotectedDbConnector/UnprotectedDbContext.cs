using GaB_Core.UnprotectedDbConnector.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace GaB_Core.UnprotectedDbConnector;

public class UnprotectedDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public UnprotectedDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Подключение к postgres со строкой подключения из настроек приложений
        options.UseNpgsql(Configuration.GetConnectionString("UnprotectedDatabase"));
    }

    /// <summary>
    /// Таблица, отвечающая за инфомрацию о вендинговых аппаратах
    /// </summary>
    public DbSet<VendingMachine> VendingMachines { get; set; } 
}