using System;

namespace TodoApi.Models
{
    public class Todo
    {
        public Todo()
        {
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Due { get; set; }
    }
}