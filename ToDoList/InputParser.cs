using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public static class InputParser
    {
        public static EditToItemInstruction ParseToEditCommand(string rawinput)
        {
            // //check to see if input is empty or does not contain separator'=' in the input
             if (string.IsNullOrWhiteSpace(rawinput) || !rawinput.Contains(EditToItemInstruction.SEPARATOR))
            {
                return new EditToItemInstruction { Property = "", Value = "" };
            }

            string[] splitParts = rawinput.Split(EditToItemInstruction.SEPARATOR); // split the two strings, split only once 

            string property = splitParts[0].Trim(); //first part trim
            string value = value = splitParts[1].Trim(); //second part trim                

            return new EditToItemInstruction { Property = property, Value = value }; //return the new edit instruction value    
        }
    }
}

