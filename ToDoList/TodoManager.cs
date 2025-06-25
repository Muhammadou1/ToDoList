using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TodoManager
    {
        //List<TodoItem> TodoCollection;   ???
        List<TodoItem> TodoCollection = new List<TodoItem>();  //Adding list into the memory

        public void CreateTodo(string Title)
        {
           
           //TodoCollection = new List<TodoItem>(); ???
            TodoItem todoItem = new TodoItem();      //Initializing a new instance
            todoItem.Title = Title;                 //Passing the Title property to the todoItem
            TodoCollection.Add(todoItem);           //Adding todoItem to the TodoCollection
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
