using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TodoItem
    {
        public required int Id { get; init; }
        public required string Title { get; set; }
        public required Status Status { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
        public DateTimeOffset? DueAt { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }

    }
}
