using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration["ConnectionStrings:ConnectionString"];
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException("Connection string is null or empty");
                }
                try
                {
                    ExecuteMigrations(connectionString);
                }
                catch (Exception ex)
                {
                    Log.Error("Database migration failed: {Message}", ex.Message);
                }
            }
            return services;
        }

        public static void ExecuteMigrations(string connectionString)
        {
            using var evolveConnection = new SqlConnection(connectionString);
            var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
            {
                Locations = new[] { "db/migrations", "db/dataset" },
                IsEraseDisabled = true
            };
            evolve.Migrate();

        }
    }
}
