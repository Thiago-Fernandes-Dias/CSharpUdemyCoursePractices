namespace CustomLinkedList;

internal class Node<T>(T? value)
{
    public readonly T? Value = value;

    public Node<T>? Next;

    public Node<T>? Previous;

    public override string ToString()
    {
        return $"Value: {Value}, Next: {NodeValueAsString(Next)}, Previous: {NodeValueAsString(Previous)}";
    }

    private static string NodeValueAsString(Node<T>? node)
    {
        return node is null ? "null" : $"{node.Value}";
    }
}