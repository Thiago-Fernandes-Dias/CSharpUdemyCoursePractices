using TodoList.TodoListOptions;

namespace TodoList
{
    public class TodoListManager(List<ITodoListOption> options)
    {
        private readonly List<Todo> Todos = [];

        public void PrintOptions()
        {
            foreach (var option in options)
            {
                Console.WriteLine(option.GetOptionDescription());
            }
        }

        public void AddTodo(Todo todo)
        {
            Todos.Add(todo);
        }
        
        public void RemoveTodoByIndex(int index)
        {
            if (index >= Todos.Count) 
            {
                throw new TodoListManagerException("Invalid index");
            }
            Todos.RemoveAt(index);
        }

        public void HandleOption(string? optionLetter)
        {
            var exception = new TodoListManagerException("Incorrect input");
            if (optionLetter == null) 
            {
                throw exception;
            }
            var option = options.Find(option => option.GetOptionLetters().Contains(optionLetter));
            if (option == null)
            {
                throw exception;
            }
            option.HandleOption(this);
        }

        public List<Todo> GetTodos() => Todos;
    }
}
