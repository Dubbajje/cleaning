namespace WebShopCleanCode;

public class Okej : ICommand
{
    Navigation navigation;
    public Okej(Navigation navigation)
    {
        this.navigation = navigation;
    }
    public void Execute()
    {
        Console.WriteLine("Okey");
    }
}