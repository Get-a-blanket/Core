using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace GaB_Core;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Core API",
                    Version = "v1"
                }
             );

            var filePath = Path.Combine(AppContext.BaseDirectory, "Documentation.xml");
            options.IncludeXmlComments(filePath);
        });

        var app = builder.Build();
        Application = app;
        Configuration = app.Configuration;
        
        //DB setup
        GetProtectedContext().Database.Migrate();
        GetUnprotectedContext().Database.Migrate();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        //app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }

    public static WebApplication Application { get; private set; }

    public static IConfiguration Configuration { get; private set; }

    public static ProtectedDbConnector.ProtectedDbContext GetProtectedContext() 
    { 
        return new ProtectedDbConnector.ProtectedDbContext(Configuration);
    }

    public static UnprotectedDbConnector.UnprotectedDbContext GetUnprotectedContext() 
    {
        return new UnprotectedDbConnector.UnprotectedDbContext(Configuration);
    }
}