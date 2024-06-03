using System.Collections;

namespace CustomLinkedList;

internal class CustomLinkedList<T> : ICustomLinkedList<T>
{
    private Node<T>? _head;

    private Node<T>? _tail;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T item)
    {
        if (_head == null)
        {
            _head = new Node<T>(item);
            _tail = _head;
        }
        else
        {
            _tail!.Next = new Node<T>(item)
            {
                Previous = _tail
            };
            _tail = _tail.Next;
        }

        Count++;
    }

    public void AddToFront(T item)
    {
        if (_head == null)
        {
            _head = new Node<T>(item);
            _tail = _head;
        }
        else
        {
            _head.Previous = new Node<T>(item)
            {
                Next = _head
            };
            _head = _head.Previous;
        }

        Count++;
    }

    public void Clear()
    {
        Node<T>? cur = _head;
        while (cur is not null)
        {
            Node<T>? temp = cur;
            cur = cur.Next;
            cur.Next = null;
        }
        _head = null;
        _tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        return this.OfType<T>().Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }
        if (array.Length < Count + arrayIndex)
        {
            throw new ArgumentException("Array is not long enought");
        }
        foreach (T value in this)
        {
            array[arrayIndex] = value;
            ++arrayIndex;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var cur = _head;
        for (; cur != null; cur = cur.Next)
            yield return cur.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool Remove(T item)
    {
        if (_head == null)
            return false;
        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            if (_head != null)
                _head.Previous = null;
            Count--;
            return true;
        }

        if (_tail.Value.Equals(item))
        {
            _tail = _tail.Previous;
            if (_tail != null)
                _tail.Next = null;
            Count--;
            return true;
        }

        var cur = _head;
        for (; cur.Next != null; cur = cur.Next)
            if (cur.Next.Value.Equals(item))
            {
                cur.Next = cur.Next.Next;
                cur.Next.Previous = cur;
                Count--;
                return true;
            }

        return false;
    }
}