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
            {
                // Count how many times each Id appears
                Dictionary<int, int> uniquesCount = new(); //Dictionary to check for Key{Id items in todo} and Value{how many time Id appears}

                foreach (TodoItem item in TodoCollection)
                {
                    bool isAdded = uniquesCount.TryAdd(item.Id, 1);  //If Id is not found add to value 1
                    if (isAdded == false)
                    {
                        uniquesCount[item.Id] += 1;                 //Increment Id count
                    }
                }

               
                if (!uniquesCount.TryGetValue(Id, out int _)) //Check to make sure the requested Id exists
                {
                    throw new Exception("Id not found.");
                }

                
                foreach (KeyValuePair<int, int> entry in uniquesCount) //Check to ensure there are no duplicate Id
                {
                    if (entry.Value > 1)
                    {
                        throw new Exception("Duplicate ID.");
                    }
                }

               
                foreach (TodoItem deleteItem in TodoCollection) // Delete the item with the matching Id in collection
                {
                    if (deleteItem.Id == Id)
                    {
                        TodoCollection.Remove(deleteItem);
                        return deleteItem;
                    }
                }

                throw new Exception("Error.");
            }

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
            Dictionary<int, int> uniquesCount = new();

            foreach (TodoItem item in TodoCollection)
            {
                bool isAdded = uniquesCount.TryAdd(item.Id, 1);
                if (!isAdded)
                {
                    uniquesCount[item.Id] += 1;
                }
            }

            if (!uniquesCount.TryGetValue(Id, out int _))  //Check if the ID exists
            {
                throw new Exception("Todo ID not found.");
            }


            foreach (KeyValuePair<int, int> entry in uniquesCount) //Check for duplicate IDs
            {
                if (entry.Value > 1)
                {
                    throw new Exception("Duplicate ID");
                }
            }

            foreach (TodoItem updateItem in TodoCollection) //Update the status
            {
                if (updateItem.Id == Id)
                {
                    updateItem.Status = Status.Complete();
                    return;
                }
            }

            throw new Exception("Error");
        }
       
        public List<TodoItem> GetAllTodoItems()
        {
            return TodoCollection;
        }
    }
}
