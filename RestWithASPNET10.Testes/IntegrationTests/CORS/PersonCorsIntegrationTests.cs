using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Testes.IntegrationTests.Tools;
using System.Net;
using System.Net.Http.Json;

namespace RestWithASPNET10.Testes.IntegrationTests.CORS
{
    [TestCaseOrderer(
    "RestWithASPNET10.Tests.IntegrationTests.Tools.PriorityOrderer",
    "RestWithASPNET10.Tests")]
    public class PersonCorsIntegrationTests : IClassFixture<SqlServerFixture>
    {
        private readonly HttpClient _httpClient;
        private static PersonDTO _person;

        public PersonCorsIntegrationTests(SqlServerFixture sqlFixture)
        {
            var factory = new CustomWebAppFactory<Program>(
                sqlFixture.ConnectionString);

            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost:3000")
                }
            );
        }

        private void AddOriginHeader(string origin)
        {
            _httpClient.DefaultRequestHeaders.Remove("Origin");
            _httpClient.DefaultRequestHeaders.Add("Origin", origin);
        }

        [Fact(DisplayName = "01 - Create Person With Allowed Origin")]
        [TestPriority(1)]
        public async Task CreatePerson_WithAllowedOrigin_ShouldReturnCreated()
        {
            // Arrange
            AddOriginHeader("http://localhost:3000");

            var request = new PersonDTO
            {
                FirstName = "Richard",
                LastName = "Stallman",
                Address = "New York City - New York - USA",
                Gender = "Male"
            };

            // Act
            var response = await _httpClient
                .PostAsJsonAsync("api/person/v1", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var created = await response.Content
                .ReadFromJsonAsync<PersonDTO>();
            created.Should().NotBeNull();
            created.Id.Should().BeGreaterThan(0);

            _person = created;
        }

        [Fact(DisplayName = "02 - Create Person With Disallowed Origin")]
        [TestPriority(2)]
        public async Task CreatePerson_WithDisallowedOrigin_ShouldReturnForbiden()
        {
            // Arrange
            AddOriginHeader("https://www.google.com/");

            var request = new PersonDTO
            {
                FirstName = "Richard",
                LastName = "Stallman",
                Address = "New York City - New York - USA",
                Gender = "Male"
            };

            // Act
            var response = await _httpClient
                .PostAsJsonAsync("api/person/v1", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);

            var content = await response.Content
                .ReadAsStringAsync();
            content.Should().Be("CORS origin not allowed.");
        }       
    }
}