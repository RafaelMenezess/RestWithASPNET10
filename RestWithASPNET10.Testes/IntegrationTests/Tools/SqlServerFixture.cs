using RestWithASPNET10.Configurations;
using Testcontainers.MsSql;

namespace RestWithASPNET10.Testes.IntegrationTests.Tools
{
    public class SqlServerFixture : IAsyncLifetime
    {
        public MsSqlContainer Container { get; }

        public string ConnectionString => Container.GetConnectionString();

        public SqlServerFixture()
        {
            Container = new MsSqlBuilder()
                .WithPassword("Admin@123")
                .WithPortBinding(0, 1433)
                .Build();
        }

        public async Task InitializeAsync()
        {
            await Container.StartAsync();
            EvolveConfig.ExecuteMigrations(ConnectionString);
        }
        public async Task DisposeAsync()
        {
            await Container.DisposeAsync();
        }
    }
}
