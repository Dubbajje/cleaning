namespace WebShopCleanCode;

public abstract class Menu
{
    
    
    protected string currentMenu { get; set; }
    protected  int currentChoice;
    protected int amountOfOptions;
    protected string option1;
    protected string option2;
    protected string option3;
    protected string option4;
    protected string info;
    protected Menu()
    {
        currentMenu = "";
        currentChoice = 0;
        amountOfOptions = 0;
        option1 = "";
        option2 = "";
        option3 = "";
        option4 = "";
        info = "";
    }
    public void DisplayOptions()
    {
        Console.WriteLine("1: " + option1);
        Console.WriteLine("2: " + option2);
        if (amountOfOptions > 2)
        {
            Console.WriteLine("3: " + option3);
        }

        if (amountOfOptions > 3)
        {
            Console.WriteLine("4: " + option4);
        }
    }
    

    public void DisplayMenu()
    {
        Console.WriteLine("1: " + option1);
        Console.WriteLine("2: " + option2);
        Console.WriteLine("3: " + option3);
        Console.WriteLine("4: " + option4);

    }
}