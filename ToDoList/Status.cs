namespace ToDoList
{
    public class Status
    {
        public static Status Open()
        {
            return new Status("Open");
        }


        public static Status Complete()
        {
            return new Status("Complete");
        }


        private Status(string status) { Value = status; }

        public string Value { get; private set; }
    }
}
