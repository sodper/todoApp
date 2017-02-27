using System;
using FluentAssertions;
using TodoApi.Models;
using TodoApi.Services;
using Xunit;
using Moq;

namespace TodoApi.UnitTest.Services
{
    public class TodoServiceTest
    {
        private TodoService _service;
        private const string NULL_ID = "123";
        private const string EXISTING_ID = "123";
        private Todo _existingTodo = new Todo
            {
                Id = 1,
                Description = "Todo1",
                Start = new DateTime(2017, 2, 28),
                Due = new DateTime(2017, 3, 10)
            };

        public TodoServiceTest()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(db => db.Get(NULL_ID)).Returns((Todo)null);          
            mockDb.Setup(db => db.Get(EXISTING_ID)).Returns(_existingTodo);          

            _service = new TodoService(mockDb.Object);
        }

        [Fact]
        public void Get_NonExistingTodo_ReturnsNull()
        {
            _service.Get(NULL_ID).Should().BeNull();
        }

        [Fact]
        public void Get_ExistingTodo()
        {
            _service.Get(EXISTING_ID).Should().ShouldBeEquivalentTo(_existingTodo);
        }
    }
}
