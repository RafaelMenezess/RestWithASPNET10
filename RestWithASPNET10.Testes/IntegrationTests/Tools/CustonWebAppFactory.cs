using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace RestWithASPNET10.Testes.IntegrationTests.Tools
{
    public class CustonWebAppFactory<TProgram> :
        WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly string _connectionString;

        public CustonWebAppFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var dict = new Dictionary<string, string>
                {
                    {
                        "ConnectionStrings:ConnectionString",
                        _connectionString
                    }
                };
                config.AddInMemoryCollection(dict!);
            });
        }
    }
}
