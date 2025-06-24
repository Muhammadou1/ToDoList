using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     public class TaskManager
    {
       public List<TodoTask> TaskCollection = new();
        //string input = Console.ReadLine();


        public void CreateTask(string title)
        {

            //while (true)
            //{
            //Console.WriteLine("Add Tasks");
            //string task = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(title))
            //{
            TaskCollection.Add(new TodoTask() {Title = title });
                        //Console.WriteLine(task);
                    //}
                    //else if (string.IsNullOrWhiteSpace(title))
                    //{
                    //    //Console.WriteLine("Task cannot be empty");
                    //}
            //}

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
