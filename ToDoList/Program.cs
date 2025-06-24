
namespace ToDoList

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to my To-Do List app");
            Console.WriteLine("----------------------------------------------");
           
            TaskManager taskmanager = new TaskManager();
            Console.WriteLine("What will you like to do?: Type create...");
            string input = Console.ReadLine();
            if(input == "create")
            {
                string task = Console.ReadLine();
                taskmanager.CreateTask(task);
                //string taskindex = taskmanager.TaskCollection[0].Title;
                Console.WriteLine("Tasks to do");
                Console.WriteLine(taskmanager.TaskCollection[0].Title);
            }

            

        }
    }
}
