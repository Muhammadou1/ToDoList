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
            Console.WriteLine($"ID: |{todoItem.Id}| Title: {todoItem.Title}, Status: |{todoItem.Status.Value}|");  //Print Items to the console
            Console.WriteLine("---------------------------------------------------");
        }

        public void RenderTodoDetail(TodoItem todoDetailItem)
        {
            Render(todoDetailItem);
            Console.WriteLine($"Created Date: {todoDetailItem.CreatedDate}");
            Console.WriteLine($"Task Completed Date:{todoDetailItem.DateCompleted?.ToString() ?? " N/A"}");
            Console.WriteLine($"Due Date: {todoDetailItem.DueAt?.ToString() ?? " N/A"}");
            //Console.WriteLine($"Last Modified Date:{todoDetailItem.LastModified?.ToString() ?? " N/A"}");
            Console.WriteLine("-------------------------------------------------");
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
