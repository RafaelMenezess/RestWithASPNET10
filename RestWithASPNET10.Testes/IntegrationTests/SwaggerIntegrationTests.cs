using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithASPNET10.Testes.IntegrationTests.Tools;

namespace RestWithASPNET10Erudio.Tests.IntegrationTests
{
    public class SwaggerIntegrationTests
        : IClassFixture<SqlServerFixture>
    {
        private readonly HttpClient _httpClient;

        public SwaggerIntegrationTests(SqlServerFixture sqlFixture)
        {
            var factory = new CustonWebAppFactory<Program>(
                sqlFixture.ConnectionString);

            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost")
                }
            );
        }

        [Fact]
        public async Task SwaggerJson_ShouldReturnSwaggerJson()
        {
            // Arrange & Act
            var response = await _httpClient
                .GetAsync("/swagger/v1/swagger.json");

            // Assert
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNull();
            content.Should().Contain("/api/person/v1");
        }

        [Fact]
        public async Task SwaggerUI_ShouldReturnSwaggerUI()
        {
            // Arrange & Act
            var response = await _httpClient
                .GetAsync("/swagger/index.html");
            // Assert
            response.EnsureSuccessStatusCode();
            0
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNull();
            content.Should().Contain("<div id=\"swagger-ui\">");
        }
    }
}