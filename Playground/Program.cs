namespace Playground
{
    internal class Program
    {
        static int i = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                RecursiveMethod();
            }
            catch (StackOverflowException)
            {
                Console.WriteLine($"executed {i} times");
            }
        }

        static void RecursiveMethod()
        {
            Console.WriteLine($"I'm calling myself again, for the {i}th time...");
            i++;
            RecursiveMethod();
        }
    }
}
