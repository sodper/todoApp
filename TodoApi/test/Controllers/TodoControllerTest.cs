using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace TodoApi.Test
{
    public class TodoControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public TodoControllerTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetAll_NoTodos_ReturnsEmptyList()
        {
            var response = await _client.GetAsync("api/todo");
            response.EnsureSuccessStatusCode();

            var actual = await response.Content.ReadAsStringAsync();
            var expected = "[]";

            Assert.Equal(expected, actual);
        }
    }
}