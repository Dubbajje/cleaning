namespace WebShopCleanCode;

public class Navigation
{
    private int amountOfOptions = 0;
    private int currentChoice = 0;
    private Button buttonLeft = new Button(new Left());
    private Button buttonRight = new Button(new Right());
    public void DisplayNavigation()
    {
        for (int i = 0; i < amountOfOptions; i++)
        {
            Console.Write(i + 1 + "\t");
        }

        Console.WriteLine();
        for (int i = 1; i < currentChoice; i++)
        {
            Console.Write("\t");
        }

        Console.WriteLine("|");

        Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
    }
}