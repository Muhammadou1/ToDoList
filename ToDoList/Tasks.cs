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
            Console.WriteLine("Enter a tasks to do");

            while (true)
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Total task " + tasks.Count);
                        break;
                    }
                    tasks.Add(input);
                }
                //string display = Console.ReadLine();
                foreach (string task in tasks)
                {
                    Console.WriteLine("Task to do " + task);
                }


            }

          
        }
    }
}
