using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TodoManager
    {
        private List<TodoItem> TodoCollection = [
            new(){ Id = 2, Title = "d", Status = Status.Open() },
            new(){ Id = 1, Title = "b", Status = Status.Open() },
            new(){ Id = 0, Title = "a", Status = Status.Open() },
            new(){ Id = 2, Title = "d", Status = Status.Open() },
            new(){ Id = 3, Title = "e", Status = Status.Open() },
            ];




        //Adding list into the memory
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
            foreach (string paramTitle in paramTitles)
            {
                CreateTodo(paramTitle);                 //Call the create method and pass in the string
            }
        }

        public TodoItem DeleteTodo(int Id)
        {
            //int IdCount = 0;
            //TodoItem? duplicateItem = null;

            //foreach (TodoItem deleteItem in TodoCollection)  //Use foreach loop to through the entire collection
            //{
            //    if (deleteItem.Id == Id)
            //    {
            //        IdCount++;

            //        duplicateItem = deleteItem;
            //    }

            //    if (IdCount == 0)
            //    {
            //        throw new Exception("No Id found");
            //    }
            //    if (IdCount > 1)
            //    {
            //        throw new Exception("Duplicate Id");
            //    }
            //}
            //TodoCollection.Remove(duplicateItem);
            //return duplicateItem;







            Dictionary<int, int> uniquesCount = new();


            foreach (TodoItem item in TodoCollection)
            {
                bool isadded = uniquesCount.TryAdd(item.Id, 1);

                if (isadded == false) {
                    uniquesCount[item.Id] += 1;
                }
            }


            if (uniquesCount.TryGetValue(Id, out int _) == false) {
                throw new Exception();
            
            }






            foreach (KeyValuePair<int, int> item in uniquesCount)
            {
                if (item.Value > 1) {
                    throw new Exception("Duplicait Id.");
                }

            }


            foreach (TodoItem deleteItem in TodoCollection)  //Use foreach loop to through the entire collection
            {
                if (deleteItem.Id == Id)
                {
                    TodoCollection.Remove(deleteItem);
                    return deleteItem;
                } 
            }



            throw new Exception("bad");

            /*
             [] x
             [1,1,2] ?
            
             [2,1, 1] ?


             [1,2,3] - 4?
             */




            //foreach (TodoItem deleteItem in TodoCollection)  //Use foreach loop to through the entire collection
            //{
            //    if (deleteItem.Id == Id)                    //Check to see if selected Id is in the TodoCollection
            //    {
            //        TodoCollection.Remove(deleteItem);      // If found delete Id 
            //        return deleteItem;                      
            //    }
            //}
            //throw new Exception();                         //If not found throw new exception 

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
            int IdStatusCount = 0;
            TodoItem? duplicateUpdateItem = null;
            foreach (TodoItem updateItem in TodoCollection)
            {
                if (updateItem.Id == Id)
                {
                    IdStatusCount++;

                    duplicateUpdateItem = updateItem;
                   updateItem.Status = Status.Complete();


                }

                //if (IdStatusCount == 0)
                //{
                //    throw new Exception("No Id found");
                //}
                //if (IdStatusCount > 1)
                //{
                //    throw new Exception("Duplicate Id");
                //}

            }

            //foreach (TodoItem updateItem in TodoCollection)      //Iterate through the entire list
            //{
            //    if (updateItem.Id == Id)                    //Check to see if Id property is = to selected Id
            //    {
            //        updateItem.Status = Status.Complete();  //Update the status from Open to Complete
            //    }
            //}
        }
        public List<TodoItem> GetAllTodoItems()
        {
            return TodoCollection;
        }
    }
}
