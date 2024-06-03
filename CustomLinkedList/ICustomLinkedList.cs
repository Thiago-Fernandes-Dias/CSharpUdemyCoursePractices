namespace CustomLinkedList;

internal interface ICustomLinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}