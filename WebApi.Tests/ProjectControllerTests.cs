using BLL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using WebApi.Controllers;
using Xunit;
using System.Threading.Tasks;
using System.Net;

namespace WebApi.Tests
{
    
    public class ProjectControllerTests
    {
        private readonly HttpClient _client;
        public ProjectControllerTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();

        }

        [Theory]
        [InlineData("GET")]
        public async Task GetAllProjects_ShouldReturnAllProjects(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/project");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET",7)]
        public async Task GetProject_ShouldReturnProjectbyId(string method, int id)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/project/{id}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData("DELETE", 1003)]
        public async Task DeleteProjectById(string method, int id)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/project/{id}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
    }
}
