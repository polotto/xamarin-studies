using System;
using System.Collections.Generic;

namespace todo
{
    public class TodoItem
    {
        public TodoItem(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public bool Completed { get; set; }

        public static IEnumerable<TodoItem> GoTodoItems()
        {
            return new List<TodoItem>
            {
                new TodoItem("Go to work"),
                new TodoItem("Have a dev meeting"),
                new TodoItem("Lunch time"),
                new TodoItem("Go to gym"),
                new TodoItem("Family time")
            };
        }
    }
}
