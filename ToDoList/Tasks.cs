using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Tasks
    //infinitely run
    {
        public List<string> tasks = new List<string>();
        public void TaskList()
        {
            Console.Clear();
            Console.WriteLine("Enter (1) to add tasks");
            Console.WriteLine("Enter (2) to view tasks");
            Console.WriteLine("Enter (3) to exit tasks");


            while (true)
            {

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Add a task to the list");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    Console.ReadLine();

                } else if (input == "2")
                {

                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks");
                    }
                    else
                    {
                        Console.WriteLine("Tasks entered");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine(tasks[i]);
                        }

                    }

                } else if (input == "3")
                {
                    Console.WriteLine("All List ");
                    foreach(string task in tasks) 
                         Console.WriteLine(task); 
                    break;

                }


            }

        }
    }
}
