using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public Status Status { get; set; }
    }
}
