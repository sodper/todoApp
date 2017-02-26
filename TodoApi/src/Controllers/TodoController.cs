using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        // GET api/todo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { };
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 1)
            {
                return new ObjectResult(new Todo()
                {
                    Id = 1,
                    Description = "Todo1",
                    Start = new DateTime(2017, 2, 28),
                    Due = new DateTime(2017, 3, 10)
                });
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/todo
        [HttpPost]
        public Todo Post(Todo todo)
        {
            todo.Id = 1;

            return todo;
        }
    }
}