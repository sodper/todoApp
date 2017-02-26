using System;
using FluentAssertions;
using TodoApi.Models;
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

        [Fact]
        public void Get_ExistingTodo()
        {
            var todo = new Todo
            {
                Id = 1,
                Description = "Todo1",
                Start = new DateTime(2017, 2, 28),
                Due = new DateTime(2017, 3, 10)
            };

            _service.Get(1).Should().ShouldBeEquivalentTo(todo);
        }
    }
}
