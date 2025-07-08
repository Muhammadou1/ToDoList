using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TodoManager
    {
        private List<TodoItem> TodoCollection = new List<TodoItem>(); //Set up my memory of all my list to be added
        int count = 0;                                         // Increment the Item ID

        public void CreateTodo(string taskTitle, DateTimeOffset? dueDate = null)
        {
            TodoItem todoItem = new TodoItem() //Initializing a new instance with object initialization   
            {                                  //Setting up my all my properties here and assiginig them a value
                Id = count++,
                Status = Status.Open(),
                Title = taskTitle,
                CreatedDate = DateTimeOffset.Now,
                DueAt = dueDate,
                DateCompleted = null,
                LastModified = null
            };
            TodoCollection.Add(todoItem);     //Adding todoItem(tasks) to the TodoCollection
        }
        public void BulkCreateTodo(string[] paramTitles) //Method using string Array for TodoManger test tasks
        {
            foreach (string paramTitle in paramTitles)
            {
                CreateTodo(paramTitle);                 //Call the create method and pass in the string
            }
        }
        public void DuplicateCheck(int Id)
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

            if (!uniquesCount.TryGetValue(Id, out int _))   //Check to make sure the requested Id exists
            {
                throw new Exception("Id not found.");
            }

            if (uniquesCount[Id] > 1)                      //Ckeck if unique Id exists more than once, if true throw exception
            {
                throw new Exception($"Duplicate ID for {Id}.");
            }
        }
        public TodoItem DeleteTodo(int Id)
        {
            {
                DuplicateCheck(Id);                             //Call DuplicateCheck method
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
            catch (Exception ex)               //catch if no Id is found
            {

                Console.WriteLine(ex);
                Console.ReadLine();
                return null;
            }
        }
        public void UpdateStatus(int Id, Status Status)
        {

            DuplicateCheck(Id);
            foreach (TodoItem updateItem in TodoCollection) //Update the status
            {
                if (updateItem.Id == Id)
                {
                    updateItem.Status = Status.Complete();
                    updateItem.DateCompleted = DateTimeOffset.Now;
                    return;
                }
            }
            throw new Exception("Error");
        }

        public bool TryUpdateStatus(int Id, Status Status)     //Method to verify Id exists in the TodoCollection
        {
            try
            {
                UpdateStatus(Id, Status.Open());    //return and delete if exist
                return true;

            }
            catch (Exception ex)                //catch if no Id is found
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                return false;
            }
        }
        public TodoItem GetById(int Id)
        {
            DuplicateCheck(Id);
            foreach (TodoItem itemDetail in TodoCollection)
            {
                if (itemDetail.Id == Id)        //Get the ID specified for detail view
                {
                    return itemDetail;
                }
            }
            throw new Exception("Error");
        }

        public TodoItem? TryGetById(int Id)
        {
            try
            {
                return GetById(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                return null;
            }
        }

        public void EditItem(TodoItem item, EditToItemInstruction editToItemInstruction)
        {
            if (editToItemInstruction.Property.ToLower() == "title")
            {
                item.Title = editToItemInstruction.Value;  //gets the title input and sets in to a value
                item.LastModified = DateTimeOffset.Now;   // adds modified date
            }
            else if (editToItemInstruction.Property.ToLower() == "status")
            {
                string statusValue = editToItemInstruction.Value.ToLower();
                if (statusValue == "complete")
                {
                    item.Status = Status.Complete();            //update status 
                    item.DateCompleted = DateTimeOffset.Now;   //set complete date
                    item.LastModified = DateTimeOffset.Now;    // adds modified date
                }
                else if (statusValue == "open")
                {
                    item.Status = Status.Open();            //change status back to open
                    item.DateCompleted = null;              // sets complete date to null
                    item.LastModified = DateTimeOffset.Now; // adds modified date
                }
                else
                {
                    throw new Exception("Invalid status value.");  // throw invalid if user sets wrong value
                }
            }
            else
            {
                throw new Exception("Use a valid input format");
            }
        }

        public List<TodoItem> GetAllTodoItems()
        {
            return TodoCollection;
        }
    }
}
