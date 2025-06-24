using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TaskManager
    {
        List<TodoTask> TaskCollection;
        //string input = Console.ReadLine();


        public void CreateTask(string title)
        {

            while (true)
            {
               // Console.WriteLine("Type create to add tasks");
                //string input = Console.ReadLine();
                //if (input.ToLower() == "create")
                //{
                    Console.WriteLine("Add Tasks");
                    string task = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(task))
                    {
                        TaskCollection.Add(new TodoTask());
                        Console.WriteLine(task);
                        //continue;
                    }
                    else if (string.IsNullOrWhiteSpace(task))
                    {
                        Console.WriteLine("Task cannot be empty");
                    }
                

                //}

            }

        }
        public void ViewTask()
        {

        }

        public void DeleteTask(int Id) 
         {

         }

        public void UpdateStatus()
        {

        }

       

    }
}
