using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.TodoListOptions
{
    public interface ITodoListOption
    {
        abstract public void HandleOption(TodoListManager todoListManager);

        abstract public List<string> GetOptionLetters();

        abstract public string GetOptionDescription();
    }
}
