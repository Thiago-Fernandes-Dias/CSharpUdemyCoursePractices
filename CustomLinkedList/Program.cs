namespace CustomLinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        var linkedList = new CustomLinkedList<int>
        {
            1, 2, 3
        };
        Console.WriteLine(linkedList.Contains(1));
        Console.WriteLine(linkedList.Contains(2));
        Console.WriteLine(linkedList.Contains(3));
        linkedList.AddToFront(5);
        foreach (var value in linkedList)
            Console.WriteLine(value);
        Console.WriteLine("Removendo items");
        linkedList.Remove(2);
        linkedList.Remove(3);
        linkedList.Remove(5);
        linkedList.Remove(1);
        linkedList.Add(1);
        linkedList.Remove(1);
        foreach (var value in linkedList)
            Console.WriteLine(value);
        for (var i = 0; i < 100; i++)
            linkedList.Add(i);
        var slice = new int[90];
        linkedList.CopyTo(slice, 10);
        foreach (var value in slice)
            Console.WriteLine(value);
    }
}