using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class EditToItemInstruction
    {
        public const string SEPARATOR = "=";
        public string  Property { get; init; } 
        public string Value { get; init; }
    }
}
