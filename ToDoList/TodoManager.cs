using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TodoManager
    {
        List<TodoItem> TodoCollection;

        public void CreateTodo(string Title)
        {

        }

        public TodoItem DeleteTodo(int Id)
        {
            return null;
        }

        public void UpdateStatus(int Id, Status Status)
        {

        }

        public List<TodoItem> GetAllTodoItems()
        {
            return TodoCollection;
        }

    }
}
