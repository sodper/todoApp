using System;
using FluentAssertions;
using TodoApi.Services;
using Xunit;

namespace TodoApi.UnitTest.Services
{
    public class TodoServiceTest
    {
        private TodoService _service;

        public TodoServiceTest()
        {
            _service = new TodoService();
        }

        [Fact]
        public void Get_NonExistingTodo_ReturnsNull()
        {
            _service.Get(123).Should().BeNull();
        }
    }
}
