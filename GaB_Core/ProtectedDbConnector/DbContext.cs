using GaB_Core.ProtectedDbConnector.Models;
using Microsoft.EntityFrameworkCore;
namespace GaB_Core.ProtectedDbConnector;
public class ApplicationContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Подключение к postgres со строкой подключения из настроек приложений
        options.UseNpgsql(Configuration.GetConnectionString("ProtectedDatabase"));
    }

    /// <summary>
    /// Таблица, отвечающая за инфомрацию о клиентах 
    /// </summary>
    public DbSet<Client> Clients { get; set; } 

    /// <summary>
    /// Таблица, отвечающая за способы оплаты
    /// </summary>
    public DbSet<PayM> PaymentMethod { get; set; }

    /// <summary>
    /// Таблица, отвечающая за регионы в номере 
    /// </summary>
    public DbSet<PhRCode> PhoneRegionCode { get; set; }

    /// <summary>
    /// Таблица, отвечающая за выдачу пледов
    /// </summary>
    public DbSet<ActiveB> ActiveBlankets { get; set; }

    /// <summary>
    /// Таблица, отвечающая за тарифы 
    /// </summary>
    public DbSet<PaymT> PaymentTariff { get; set; }
}