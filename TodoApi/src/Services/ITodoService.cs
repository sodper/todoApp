using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        List<Todo> GetAll();
        Todo Get(string id);
        void Delete(string id);
        string Save(Todo todo);
        void Update(Todo todo);
    }
}