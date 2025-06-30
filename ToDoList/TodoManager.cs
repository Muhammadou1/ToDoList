using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TodoManager
    {
        private List<TodoItem> TodoCollection = new List<TodoItem>();  //Adding list into the memory
        int count = 0;                                         // Increment the Item ID
       
        public void CreateTodo(string paramTitle, DateTime dateTime)
        {
            TodoItem todoItem = new TodoItem() //Initializing a new instance with object initialization   
            { 
                Id = count++, 
                Status = Status.Open(), 
                Title = paramTitle,
                DueDate = dateTime,
            };                      
            TodoCollection.Add(todoItem);     //Adding todoItem to the TodoCollection
        }
        public void BulkCreateTodo(string[] paramTitles) //Method using string Array for TodoManger test
        {
            foreach (string paramTitle in paramTitles)
            {
                CreateTodo(paramTitle, DateTime.Today.AddDays(1));  //Call the create method and pass in the string
            }                                                       // Also Adds a hard codeded due date for the due date on test tasks
        }

        public TodoItem DeleteTodo(int Id)
        {
            TodoItem deleteTodo = TodoCollection.Single(deleteItem => deleteItem.Id == Id);  //Grab the Item by Id in the TodoCollection
            TodoCollection.Remove(deleteTodo);               //Remove the selected item Id 
            return deleteTodo;
        }

        public TodoItem? TryDeleteTodo(int Id)  //Method to verify Id exists in the TodoCollection
        {
            try
            {
               return DeleteTodo(Id);       //return and delete if exist

            }
            catch (Exception)               //catch if no Id is found
            {

                return null;
            }
        }
        public void UpdateStatus(int Id, Status Status)
        {
            foreach (TodoItem updateItem in TodoCollection)      //Iterate through the entire list
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
