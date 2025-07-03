namespace ToDoList
{
    public class App
    {
        TaskViewer TaskViewer = new();
        TodoManager todoManager = new();


        public void Initialize()
        {
            //Testing Todo Manager Tasks
            string[] todo = [
                "Laundry",
                "Shopping",
               ];
            todoManager.BulkCreateTodo(todo);
        }


        public void Mainloop()
        {
            while (true)
            {
                Console.WriteLine("Current session task:");
                TaskViewer.Render(todoManager.GetAllTodoItems());

                string? command = Console.ReadLine();
                switch (command)
                {
                    case "create":
                        Console.Clear();
                        Console.WriteLine("Enter your todo task.");
                        string? task = Console.ReadLine();

                        Console.WriteLine("Enter due date (mm/dd/yyyy)");
                        string? dateInput = Console.ReadLine();
                        DateTimeOffset? dueDate = null;
                        if (!string.IsNullOrWhiteSpace(dateInput))
                        {
                            if (!DateTimeOffset.TryParse(dateInput, out DateTimeOffset parseDate))
                            {
                                Console.WriteLine("Invalid date, No due date set");
                                Console.ReadLine();
                            }
                            else
                            {
                                dueDate = parseDate;
                            }
                            todoManager.CreateTodo(task ?? "EMPTY", dueDate);
                        }
                        break;

                    case "update":
                        Console.Clear();
                        Console.WriteLine("Enter your todo Id. To Update status to 'Complete'");
                        int updateId = int.Parse(Console.ReadLine() ?? "0");
                        bool isUpdated = todoManager.TryUpdateStatus(updateId, Status.Complete());
                        if (!isUpdated)
                        {
                            Console.WriteLine("Invalid Id, press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Task updated");
                        Console.ReadLine();
                        break;

                    case "delete":
                        Console.Clear();
                        Console.WriteLine("Enter your todo Id. To delete");
                        int deleteId = int.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Are you sure you want to delete this task? [yes/no]");
                        string? deleteDialog = Console.ReadLine();
                        if (deleteDialog == "yes")
                        {
                            TodoItem? checkDelete = todoManager.TryDeleteTodo(deleteId);
                            if (checkDelete == null)
                            {
                                Console.WriteLine("Invalid Id entered, press enter to continue");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("Task deleted");
                            Console.ReadLine();
                        }
                        else if (deleteDialog == "no")
                        {
                            continue;
                        }
                        break;

                    case "detail":
                        Console.Clear();
                        Console.WriteLine("Enter your todo Id. To view detail");
                        int viewId = int.Parse(Console.ReadLine());
                        TodoItem? viewDetail = todoManager.TryGetById(viewId);
                        if(viewDetail == null)
                        {
                            Console.WriteLine("Invalid Id, press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                        TaskViewer.RenderTodoDetail(viewDetail);
                        Console.ReadLine();
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
