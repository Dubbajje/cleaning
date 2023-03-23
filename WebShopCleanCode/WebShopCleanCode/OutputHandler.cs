namespace WebShopCleanCode;

public class OutputHandler
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine();
    }

    public void DisplayMessageWithArgument(string argument, string message)
    {
        Console.WriteLine();
        Console.WriteLine(argument + message);
        Console.WriteLine();
    }
}