namespace WebShopCleanCode;

public class Navigation
{
    public int amountOfOptions = 3;
    public int currentChoice = 1;
    private Dictionary<string, Button> commands = new Dictionary<string, Button>();

    public Navigation()
    {
        commands.Add("l", new Button(new Left(this)));
        commands.Add("left", new Button(new Left(this)));
        commands.Add("r", new Button(new Right(this)));
        commands.Add("right", new Button(new Right(this)));
        commands.Add("o", new Button(new Okej(this)));
        commands.Add("k", new Button(new Okej(this)));
        commands.Add("okej", new Button(new Okej(this)));
        
    }
    
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

    public void LoopThroughCommands(string choice)
    {
        foreach (var comm in commands)
        {
            if (comm.Key.Equals(choice))
            {
                comm.Value.PushButton();
            }

        }
    }
}