using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private IDatabase _db;

        public TodoService(IDatabase db)
        {
            _db = db;
        }
        public void Delete(string id)
        {
            _db.Delete(id);
        }

        public Todo Get(string id)
        {
            return _db.Get(id);
        }

        public List<Todo> GetAll()
        {
            return _db.GetAll();
        }

        public string Save(Todo todo)
        {
            return _db.Save(todo);
        }

        public bool Update(Todo todo)
        {
            return _db.Update(todo);
        }
    }
}