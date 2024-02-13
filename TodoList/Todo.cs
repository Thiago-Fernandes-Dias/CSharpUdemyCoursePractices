using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Order
    {
        public readonly string Item;

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (value.Year == DateTime.Now.Year)
                {
                    _date = value;
                }
            }
        }

        public Order(string item, DateTime date)
        {
            Item = item;
            Date = date;
        }
    }

    public class Todo : IEquatable<Todo>
    {
        public Todo(string text)
        {
            this.Text = text;
        }

        public string Text { get; }

        public override bool Equals(object? obj)
        {
            var o = new Order("tem", DateTime.Now);
            if (obj is Todo todo)
            {
                return todo.Text == this.Text;
            }
            return false;
        }

        public bool Equals(Todo? other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
    }
}
