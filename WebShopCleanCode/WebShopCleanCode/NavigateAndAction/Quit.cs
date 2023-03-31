namespace WebShopCleanCode;

public class Quit : ICommand
{

    public void Execute(int currentChoice)
    {
        Console.WriteLine("The console powers down. You are free to leave.");
        //Environment.Exit(0);
    }
}