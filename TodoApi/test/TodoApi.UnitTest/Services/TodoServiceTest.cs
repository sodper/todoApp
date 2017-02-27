using System;
using FluentAssertions;
using TodoApi.Models;
using TodoApi.Services;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace TodoApi.UnitTest.Services
{
    public class TodoServiceTest
    {
        private const string NULL_ID = "123";
        private const string EXISTING_ID = "123";
        private Todo EXISTING_TODO = new Todo
            {
                Id = 1,
                Description = "Todo1",
                Start = new DateTime(2017, 2, 28),
                Due = new DateTime(2017, 3, 10)
            };

        public TodoServiceTest()
        {
        }

        [Fact]
        public void Get_NonExistingTodo_ReturnsNull()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(db => db.Get(NULL_ID)).Returns((Todo)null);          
            var service = new TodoService(mockDb.Object);

            service.Get(NULL_ID).Should().BeNull();
        }

        [Fact]
        public void Get_ExistingTodo()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(db => db.Get(EXISTING_ID)).Returns(EXISTING_TODO);
            var service = new TodoService(mockDb.Object);

            service.Get(EXISTING_ID).ShouldBeEquivalentTo(EXISTING_TODO);
        }

        [Fact]
        public void GetAll_NoTodos_ReturnsEmptyList()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(db => db.GetAll()).Returns(new List<Todo>());        
            var service = new TodoService(mockDb.Object);

            service.GetAll().Should().BeEmpty();
        }
    }
}
