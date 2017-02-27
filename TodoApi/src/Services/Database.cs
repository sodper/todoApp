using System;
using System.Collections.Generic;
using LiteDB;
using Microsoft.AspNetCore.Hosting;
using TodoApi.Models;

namespace TodoApi.Services
{
    class Database : IDatabase
    {
        private readonly string _dbPath;

        public Database(IHostingEnvironment env)
        {
            _dbPath = $"{env.ContentRootPath}\\Data.db";
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Todo Get(string id)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<Todo>("todos");
                return collection.FindById(new ObjectId(id));
            }
        }

        public List<Todo> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(Todo todo)
        {
            throw new NotImplementedException();
        }

        public void Update(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}