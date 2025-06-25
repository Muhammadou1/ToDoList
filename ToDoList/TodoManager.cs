using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TodoManager
    {
        List<TodoItem> TodoCollection = new List<TodoItem>();  //Adding list into the memory
        int count = 0;                                         // Increment the Item ID
       
        public void CreateTodo(string paramTitle)
        {
            TodoItem todoItem = new TodoItem() { Id = count++, Status = Status.Open(),  Title = paramTitle };    //Initializing a new instance with object initialization   
            TodoCollection.Add(todoItem);                      //Adding todoItem to the TodoCollection
        }
        
        public TodoItem DeleteTodo(int Id)
        {
            return null;
        }
        
        public void UpdateStatus(int Id, Status Status)
        {
            foreach (var updateItem in TodoCollection)      //Iterate through the entire list
            {
                if (updateItem.Id == Id)                    //Check to see if Id property is = to selected Id
                {
                    updateItem.Status = Status.Complete();  //Update the status from Open to Complete
                }
            }
        }
       
        public List<TodoItem> GetAllTodoItems()
        {
            return TodoCollection;
        }
    }
}
