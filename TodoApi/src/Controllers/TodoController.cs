using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        // GET api/todo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]{ };
        }
    }
}