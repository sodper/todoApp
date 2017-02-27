using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface IDatabase
    {
        List<Todo> GetAll();
        Todo Get(string id);
        void Delete(string id);
        int Save(Todo todo);
        void Update(Todo todo);
    }
}