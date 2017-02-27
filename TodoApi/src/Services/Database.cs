using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(string id)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<Todo>("todos");
                collection.Delete(new ObjectId(id));
            }
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
            using(var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<Todo>("todos");
                return collection.FindAll().ToList();
            }
        }

        public string Save(Todo todo)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<Todo>("todos");
                var id = collection.Insert(todo);

                collection.EnsureIndex(x => x.Id);

                return id.ToString();
            };
        }

        public bool Update(Todo todo)
        {
            using(var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<Todo>("todos");
                return collection.Update(todo);
            };
        }
    }
}