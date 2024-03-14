using GaB_Core.ProtectedDbConnector.Models;
using Microsoft.EntityFrameworkCore;
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
        if (Program.Application?.Environment.IsDevelopment() ?? false)
        {
            options.EnableSensitiveDataLogging(true);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //настройка связей модели базы данных 
        modelBuilder.Entity<Client>()
            .HasMany(c => c.ActiveBlankets)
            .WithOne(ab => ab.Client)
            .HasForeignKey(ab => ab.ClientId)
            .HasPrincipalKey(c => c.Id);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.PhoneRegionCode)
            .WithMany()
            .HasForeignKey(c => c.PhoneRegionCodeId)
            .HasPrincipalKey(prc => prc.Id);

        modelBuilder.Entity<ActiveBlanket>()
            .HasOne(ab => ab.PaymentTariff)
            .WithMany()
            .HasForeignKey(ab => ab.PaymentTariffId)
            .HasPrincipalKey(pt => pt.Id);

        //обязательные данные
        var russianRegionCode = new PhoneRegionCode { Id = 7, Name = "RU" };
        modelBuilder.Entity<PhoneRegionCode>().HasData(
            russianRegionCode
        );
        // TODO: заполнять типы тарифов если они не заполнены https://metanit.com/sharp/efcore/2.14.php
        //modelBuilder.Entity<PaymentTariff>().HasData(
        //    new PaymentTariff { },
        //    new PaymentTariff { }
        //);

        //тестовые данные
        if (WebApplication.CreateBuilder().Build().Environment.IsDevelopment()) //TODO проверить создает ли на prod
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("fa2e2a6f-6703-4ef0-8765-941d20d10a70"),
                    DateOfRegistration = DateTime.UtcNow,
                    Email = "info@getablanket.ru",
                    PhoneRegionCodeId = russianRegionCode.Id,
                    PhoneNumber = 1234567890,
                    ActiveBlankets = []
                }
            );
        }
    }

    /// <summary>
    /// Таблица, отвечающая за инфомрацию о клиентах 
    /// </summary>
    public DbSet<Client> Clients { get; set; } 

    /// <summary>
    /// Таблица, отвечающая за регионы в номере 
    /// </summary>
    public DbSet<PhoneRegionCode> PhoneRegionCodes { get; set; }

    /// <summary>
    /// Таблица, отвечающая за выдачу пледов
    /// </summary>
    public DbSet<ActiveBlanket> ActiveBlankets { get; set; }

    /// <summary>
    /// Таблица, отвечающая за тарифы 
    /// </summary>
    public DbSet<PaymentTariff> PaymentTariffs { get; set; }
}