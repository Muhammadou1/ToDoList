using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TaskViewer
    {
        public void Render(TodoItem todoItem)
        {
            Console.WriteLine($"ID: {todoItem.Id}, Title: {todoItem.Title}, Status: {todoItem.Status.Value}");  //Print Items to the console
        }

        public void Render(List<TodoItem> todoAllItems)
        {
            foreach (TodoItem viewItem in todoAllItems)  //Loop through the list and display items entered
            {
                Render(viewItem);                        //Display render items created in the CW
            }
        }
    }
}
