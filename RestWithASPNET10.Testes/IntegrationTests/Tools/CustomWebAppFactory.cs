using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithASPNET10.Model.Context;
using System.Reflection;

namespace RestWithASPNET10.Testes.IntegrationTests.Tools
{
    public class CustomWebAppFactory<TProgram> :
        WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly string _connectionString;

        public CustomWebAppFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var testConfigPath = Path.Combine(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location)!,
                    "appsettings.Test.json");

                config.Sources.Clear();
                config.AddJsonFile(
                    testConfigPath,
                    optional: false,
                    reloadOnChange: true);
            });
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<MSSQLContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<MSSQLContext>(options =>
                    options.UseSqlServer(_connectionString));
            });
        }
    }
}
