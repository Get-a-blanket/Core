using GaB_Core.ProtectedDbConnector.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace GaB_Core.ProtectedDbConnector;

public class ProtectedDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ProtectedDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Подключение к postgres со строкой подключения из настроек приложений
        options.UseNpgsql(Configuration.GetConnectionString("ProtectedDatabase"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: заполнять типы тарифов если они не заполнены https://metanit.com/sharp/efcore/2.14.php
        //modelBuilder.Entity<PaymentTariff>().HasData(
        //    new PaymentTariff { },
        //    new PaymentTariff { }
        //);
    }

    /// <summary>
    /// Таблица, отвечающая за инфомрацию о клиентах 
    /// </summary>
    public DbSet<Client> Clients { get; set; } 

    /// <summary>
    /// Таблица, отвечающая за регионы в номере 
    /// </summary>
    public DbSet<PhoneRegionCode> PhoneRegionCode { get; set; }

    /// <summary>
    /// Таблица, отвечающая за выдачу пледов
    /// </summary>
    public DbSet<ActiveBlanket> ActiveBlankets { get; set; }

    /// <summary>
    /// Таблица, отвечающая за тарифы 
    /// </summary>
    public DbSet<PaymentTariff> PaymentTariff { get; set; }
}