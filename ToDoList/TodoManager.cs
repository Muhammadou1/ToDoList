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
       
        public void CreateTodo(string paramTitle)
        {
            TodoItem todoItem = new TodoItem() //Initializing a new instance with object initialization   
            { 
                Id = count++, 
                Status = Status.Open(), 
                Title = paramTitle 
            };                      
            TodoCollection.Add(todoItem);     //Adding todoItem to the TodoCollection
        }
        public void BulkCreateTodo(string[] paramTitles) //Method using string Array for TodoManger test
        {
            foreach(string paramTitle in paramTitles)
            {
                CreateTodo(paramTitle);                 //Call the create method and pass in the string
            }
        }

        public TodoItem DeleteTodo(int Id)
        {
            foreach (TodoItem deleteItem in TodoCollection)  //Use foreach loop to through the entire collection
            {
                if (deleteItem.Id == Id)                    //Check to see if selected Id is in the TodoCollection
                {
                    TodoCollection.Remove(deleteItem);      // If found delete Id 
                    return deleteItem;                      
                }

            }
            throw new Exception();                         //If not found throw new exception 
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
