using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Configurations
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDataBaseConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
