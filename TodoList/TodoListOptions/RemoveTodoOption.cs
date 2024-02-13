namespace TodoList.TodoListOptions
{
    public class RemoveTodoOption(SeeAllTodosOption seeAllTodosOption) : ITodoListOption
    {
        private readonly SeeAllTodosOption seeAllTodosOption = seeAllTodosOption;

        public string GetOptionDescription()
        {
            return "[R]emove Todo";
        }

        public List<string> GetOptionLetters()
        {
            return ["r", "R"];
        }

        void ITodoListOption.HandleOption(TodoListManager todoListManager)
        {
            seeAllTodosOption.HandleOption(todoListManager);
            var todos = todoListManager.GetTodos();
            if (todos.Count == 0)
                return;
            while (true)
            {
                Console.Write("Select the index of the TODO you want to remove: ");
                var input = Console.ReadLine();
                if (input == null || input == "")
                {
                    Console.WriteLine("Selected index cannot be empty.");
                    continue;
                }
                else if (int.TryParse(input, out int todoIndex) && todos.Count <= todoIndex)
                {
                    var todoText = todos[todoIndex - 1].Text;
                    Console.WriteLine($"TODO removed: {todoText}");
                    todoListManager.RemoveTodoByIndex(todoIndex - 1);
                    return;
                }
                Console.WriteLine("The given index is not valid.");
            }
        }
    }
}
