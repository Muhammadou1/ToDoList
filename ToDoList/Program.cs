
namespace ToDoList

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to my To-Do List app");
            Console.WriteLine("----------------------------------------------");
           
            TodoManager taskmanager = new TodoManager();
            Console.WriteLine("What will you like to do?: Type create...");
            string input = Console.ReadLine();
            if(input == "create")
            {
                string task = Console.ReadLine();
                taskmanager.CreateTodo(task);
                //string taskindex = taskmanager.TaskCollection[0].Title;
                Console.WriteLine("Tasks to do");
                //Console.WriteLine(taskmanager.TodoCollection[0].Title);
            }

            

        }
    }
}
