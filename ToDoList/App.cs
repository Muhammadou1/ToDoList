using Microsoft.VisualBasic;

namespace ToDoList
{
    public class App
    {
        TaskViewer TaskViewer = new();
        TodoManager todoManager = new();
        public void Initialize()
        {
            //Testing Todo Manager
            string[] todo = [
                    "Laundry",
                    "Cook",
                    "Shopping",
               ];
            todoManager.BulkCreateTodo(todo);
        }

        public void Mainloop()
        {
            while (true) {
                Console.WriteLine("Current session task:");
                TaskViewer.Render(todoManager.GetAllTodoItems());

                string? command = Console.ReadLine();

                switch(command) {
                    case "create":
                        Console.Clear();
                        Console.WriteLine("Enter you todo task.");
                        string? task = Console.ReadLine();

                        Console.WriteLine("Enter due date (MM/dd/yyyy");
                        string? dueDateInput = Console.ReadLine();
                        DateTime dueDate;
                        if(!DateTime.TryParse(dueDateInput, out dueDate))
                        {
                            dueDate = DateTime.Now;
                            Console.WriteLine("Invalid date");
                            Console.ReadLine();
                            break;
                        }
                        todoManager.CreateTodo(task ?? "EMPTY", dueDate);
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
                        Console.WriteLine("Are you sure you want to delete this task? [yes/no]");
                        string? deleteDialog = Console.ReadLine();
                        if(deleteDialog == "yes")
                        {
                         TodoItem? checkDelete =  todoManager.TryDeleteTodo(deleteId);
                            if(checkDelete == null)
                            {
                                Console.WriteLine("Invalid Id entered, press enter to continue");
                                Console.ReadLine();
                            }
                            Console.WriteLine("Task deleted");
                            Console.ReadLine();
                        } else if(deleteDialog == "no")
                        {
                          continue;
                        } 
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
