namespace ToDoList
{
    public class App
    {
        private TaskViewer TaskViewer = new();
        private TodoManager todoManager = new();


        public void Initialize()
        {
            Console.WriteLine("Tutorials:");
            Console.WriteLine("Type 'create' to create a task");
            Console.WriteLine("Type 'update' to update a task");
            Console.WriteLine("Type 'delete' to delete a task");
            Console.WriteLine("Type 'detail' to view detail of a task");
            Console.WriteLine("Type 'edit' to edit a task");
            Console.WriteLine("Type 'exit' to exit a application");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Press Enter to get started");
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
                    case Global.CREATE:
                        Console.Clear();
                        Console.WriteLine("Enter your todo task.");
                        string? taskInput = Console.ReadLine();

                        Console.WriteLine("Enter due date (mm/dd/yyyy)");
                        string? dateInput = Console.ReadLine();
                        DateTimeOffset? dueDate = null;
                        if (!string.IsNullOrWhiteSpace(dateInput))
                        {
                            if (DateTimeOffset.TryParse(dateInput, out DateTimeOffset parseDate))
                            {
                                dueDate = parseDate;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date, No due date set");
                                Console.ReadLine();
                            }
                            todoManager.CreateTodo(taskInput ?? "EMPTY", dueDate);
                        }
                        break;

                    case Global.UPDATE:
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

                    case Global.DELETE:
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

                    case Global.DETAIL:
                        Console.Clear();
                        Console.WriteLine("Enter your todo Id. To view detail");
                        int viewId = int.Parse(Console.ReadLine() ?? "0");
                        TodoItem? viewDetail = todoManager.TryGetById(viewId);
                        if (viewDetail == null)
                        {
                            Console.WriteLine("Invalid Id, press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                        TaskViewer.RenderTodoDetail(viewDetail);

                        string? anotherCommand = Console.ReadLine();
                        switch (anotherCommand)
                        {
                            case Global.EDIT:
                                Console.Clear();
                                Console.WriteLine("Enter property and value to edit {prop}=value");
                                EditToItemInstruction edit = InputParser.ParseToEditCommand(Console.ReadLine() ?? "");
                                try
                                {
                                    todoManager.EditItem(viewDetail, edit);
                                    Console.WriteLine("Todo item updated successfully. Press Enter to continue.");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Error: Invalid");
                                }
                                Console.ReadLine();
                                break;
                        }
                        break;

                    case Global.EXIT:
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
