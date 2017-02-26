using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using TodoApi.Models;
using Xunit;
using FluentAssertions;

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

        [Fact]
        public async Task Get_ExistingTodo()
        {
            var response = await _client.GetAsync("api/todo/1");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<Todo>(json);
            var expected = new Todo(){
                Id = 1,
                Description = "Todo1",
                Start = new DateTime(2017, 2, 28),
                Due = new DateTime(2017, 3, 10)
            };

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task Get_NonExistingTodo_ReturnsNotFound()
        {
            var response = await _client.GetAsync("api/todo/2");

            var actual = response.StatusCode;
            var expected = HttpStatusCode.NotFound;

            Assert.Equal(expected, actual);
        }
    }
}
