namespace ToDoList
{
    public class App
    {
        public void Initialize()
        {

        }

        public void Mainloop()
        {
            TaskViewer TaskViewer = new();
            TodoManager todoManager  = new();
            while (true) {
                Console.WriteLine("Current session task:");
                TaskViewer.Render(todoManager.GetAllTodoItems());

                string? command = Console.ReadLine();

                switch(command) {
                    case "create":
                        Console.Clear();
                        Console.WriteLine("Enter you todo task.");
                        string? task = Console.ReadLine();
                        todoManager.CreateTodo(task ?? "EMPTY");
                            break;
                    case "update":
                        Console.Clear();
                        Console.WriteLine("Enter you todo Id. To Update status to 'Complete'");
                        int updateId = int.Parse(Console.ReadLine() ?? "0");
                        todoManager.UpdateStatus(updateId, Status.Complete());
                            break;
                    case "delete":
                        Console.Clear();
                        Console.WriteLine("Enter you todo Id. To delete");
                        int deleteId = int.Parse(Console.ReadLine() ?? "0");
                        todoManager.DeleteTodo(deleteId);
                            break;
                     case "exit":
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                            return;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        public void Shutdown()
        {

        }
    }
}
