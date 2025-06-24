
namespace ToDoList

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to my To-Do List app");
            Console.WriteLine("----------------------------------------------");
           
            TaskManager taskmange = new TaskManager();
            //taskmange.CreateTask("Task Name");
            Console.WriteLine("What will you like to do?: create...");
            string input = Console.ReadLine();
            if(input == "create")
            {
                taskmange.CreateTask("Title");
            }

            

        }
    }
}
