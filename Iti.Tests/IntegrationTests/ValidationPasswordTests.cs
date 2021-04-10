using Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Iti.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Iti.Tests.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public class ValidationPasswordTests
    {
        private readonly HttpClient _httpClient;
        private const string MEDIA_TYPE = "application/json";
        public ValidationPasswordTests()
        {
            var _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }

        [Fact]
        public async Task Should_Return_SatusCode_200_and_True_When_Valid_Password_IS_Provided()
        {
            var validPassword = JsonConvert.SerializeObject(new EntityPassword("Abcd.1234"));
            var data = new StringContent(validPassword, Encoding.UTF8, MEDIA_TYPE);
            var response = await _httpClient.PostAsync("/api/Password/validation", data);
            response.StatusCode.Should().Be(200);
            response.Content.ReadAsStringAsync().Result.Should().Be("true");
        }

        [Fact]
        public async Task Should_Return_SatusCode_200_and_False_When_No_Valid_Password_IS_Provided()
        {
            var invalidPassword = JsonConvert.SerializeObject(new EntityPassword("AbcdAbc123"));
            var data = new StringContent(invalidPassword, Encoding.UTF8, MEDIA_TYPE);
            var response = await _httpClient.PostAsync("/api/Password/validation", data);
            response.StatusCode.Should().Be(200);
            response.Content.ReadAsStringAsync().Result.Should().Be("false");
        }

        [Fact]
        public async Task Should_Return_BadRequest_When_No_Is_Provided()
        {
            var nullPassword = JsonConvert.SerializeObject(null);
            var data = new StringContent(nullPassword, Encoding.UTF8, MEDIA_TYPE);
            var response = await _httpClient.PostAsync("/api/Password/validation", data);
            response.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task Should_Return_BadRequest_When_Empty_Password_Is_Provided()
        {
            var nullPassword = JsonConvert.SerializeObject(new EntityPassword(""));
            var data = new StringContent(nullPassword, Encoding.UTF8, MEDIA_TYPE);
            var response = await _httpClient.PostAsync("/api/Password/validation", data);
            response.StatusCode.Should().Be(400);
        }
    }
}
