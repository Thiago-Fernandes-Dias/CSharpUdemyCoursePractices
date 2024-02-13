
namespace TodoList.TodoListOptions
{
    public class SeeAllTodosOption : ITodoListOption
    {
        public string GetOptionDescription()
        {
            return "[S]ee all todos";
        }

        public List<string> GetOptionLetters()
        {
            return ["S", "s"];
        }

        public void HandleOption(TodoListManager todoListManager)
        {
            var todos = todoListManager.GetTodos();
            if (todos.Count == 0)
                Console.WriteLine("No TODOs have been added yet.");
            else
                for (int i = 0; i < todos.Count; i++)
                    Console.WriteLine($"{i + 1}: {todos[i].Text}");
        }
    }
}
