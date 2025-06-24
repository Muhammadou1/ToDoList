namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Status:");
            Console.WriteLine(Status.Open());

            Console.WriteLine("*******");

            Console.WriteLine("Status:");
            Console.WriteLine(Status.Complete);



            // I need to got store
            
            
            // Go to store Set to new open status
            Todo item = new Todo(){ 
                name = "Go to Store",
                status = Status.Open()
            };

            // change status.
            item.status = new Status(); // does not compile
            
            //Change status Correct way.
            item.status = Status.Complete();
        }
    }


    /// <summary>
    /// Status Example
    /// </summary>
    public class Status {
        public string Value { get; private set; }
        private Status(string value) {
            Value = value;
        }

        public static Status Open() {
            return new Status("Open");
        }

        public static Status Complete() {
            return new Status("Complete");
        }
    }

    //public class StatusString { 
    //    public const string OPEN = "Open";
    //    public const string COMPLETE = "Complete";
    //}

    public class Todo {
        public string name { get; set; }
        public Status status { get; set; }
    }
}
