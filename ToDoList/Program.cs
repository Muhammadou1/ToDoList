
namespace ToDoList

{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();

            app.Initialize();
            app.Mainloop();
            app.Shutdown();
        }
    }
}
