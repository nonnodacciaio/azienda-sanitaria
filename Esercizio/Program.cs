using Esercizio.Configuration;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Esercizio;

public class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("Resources/config.json", false)
            .Build();

        var appSettings = configuration.Get<AppSettings>();
        var config = new Config(appSettings);

        var appBuilder = WebApplication.CreateBuilder(args);

        appBuilder.Host.ConfigureServices(services =>
        {
            services.AddTransient<IPersonsRepository, PersonsRepository>();
            services.AddTransient<IAddressesRepository, AddressesRepository>();
            services.AddTransient<IPersonReader, MySqlPersonReader>();
            services.AddTransient<PersonExtService>();

            services.AddDbContext<EsercizioDbContext>(Base64FormattingOptions =>
            {
                options.UseMySql(Config.Settings.DbConnectionString, ServerVersion.Autodetect(Config.Settings.DbConnectionString), mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(100, TimeSpan.FromSeconds(5), null);
                });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        });

        var app = appBuilder.Build();

        var dbContext = app.Services.GetRequiredService<EsercizioDbContext>();

        dbContext.Database.Migrate();

        app.UseRouting();
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        new DbContextInitializer(dbContext).Initialize();

        var urlBase = $"http://*:{(Debugger.IsAttached ? "8000" : "80")}";

        app.Run(urlBase);
    }
}