int firstNumber, secondNumber, result;
try
{
    Console.WriteLine("Hello!");
    Console.Write("Input the first number: ");
    firstNumber = ReadNumber(Console.ReadLine);
    Console.Write("Input the second number: ");
    secondNumber = ReadNumber(Console.ReadLine);
    Console.Write("What do you want to do with those numbers? ");
    Console.WriteLine("What do you want to do with those numbers?");
    Console.WriteLine("[A]dd");
    Console.WriteLine("[S]ubtract");
    Console.WriteLine("[M]ultiply");
    result = PerformOperation(firstNumber, secondNumber, Console.ReadLine);
    Console.WriteLine($"Result: {result}");
    ExitProgram();
} 
catch (Exception e)
{
    Console.WriteLine(e.Message);
    ExitProgram();
}

int ReadNumber(Func<string?> readerCallback)
{
    if (int.TryParse(readerCallback(), out int number)) return number;
    throw new Exception("Invalid text");
}

int PerformOperation(int n1, int n2, Func<string?> readerCallback) => readerCallback() switch
{
    "A" => firstNumber + secondNumber,
    "S" => firstNumber - secondNumber,
    "M" => firstNumber * secondNumber,
    _ => throw new Exception("Invalid operation")
};

void ExitProgram()
{
    Console.WriteLine("Press any key to quit...");
    Console.ReadKey();
}

