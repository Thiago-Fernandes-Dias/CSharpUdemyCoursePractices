using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TodoList.TodoListOptions;

namespace TodoList
{
    internal class TodoListManagerException : Exception
    {
        public TodoListManagerException(string? message) : base(message) { }
    }
}
