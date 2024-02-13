using System.Runtime.CompilerServices;
using TodoList.TodoListOptions;

namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITodoListOption> options =
            [
                new RemoveTodoOption(new()),
                new AddTodoOption(),
                new SeeAllTodosOption(),
            ];
            var todoListManager = new TodoListManager(options);
            while (true)
            {
                todoListManager.PrintOptions();
                var option = Console.ReadLine();
                if (option == "e" || option == "E")
                {
                    break;
                }
                try
                {
                    todoListManager.HandleOption(option);
                }
                catch (TodoListManagerException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
