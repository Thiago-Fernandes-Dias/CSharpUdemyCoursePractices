using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.TodoListOptions
{
    public class AddTodoOption : ITodoListOption
    {
        public string GetOptionDescription()
        {
            return "[A]dd Todo";
        }

        public List<string> GetOptionLetters()
        {
            return ["A", "a"];
        }

        void ITodoListOption.HandleOption(TodoListManager todoListManager)
        {
            while (true) 
            {
                Console.Write("Enter the TODO description: ");
                var todoText = Console.ReadLine();
                if (todoText == null)
                {
                    Console.WriteLine("The description cannot be empty.");
                    continue;
                }
                Todo todo = new(todoText);
                if (todoListManager.GetTodos().Contains(todo))
                {
                    Console.WriteLine("The description must be unique.");
                    continue;
                }
                todoListManager.AddTodo(new(todoText));
                Console.WriteLine($"TODO successfully added: {todoText}");
                break;
            }
        }
    }
}
