using System.ComponentModel.Design;

namespace WebShopCleanCode;

public class Navigation
{
    private Dictionary<string, Button> commands = new Dictionary<string, Button>();
    private MenuContext context;
    private WebShop webshop;
    

    public Navigation(MenuContext context, WebShop webShop)
    {
        this.context = context;
        this.webshop = webShop;
        commands.Add("l", new Button(new Left(this, webShop)));
        commands.Add("left", new Button(new Left(this, webShop)));
        commands.Add("r", new Button(new Right(this, webShop, context)));
        commands.Add("right", new Button(new Right(this, webShop, context)));
        commands.Add("ok", new Button(new Okey(this,context)));
        commands.Add("o", new Button(new Okey(this, context)));
        commands.Add("k", new Button(new Okey(this, context)));
        commands.Add("okey", new Button(new Okey(this, context)));
        commands.Add("back", new Button(new Back(context, webShop)));
        commands.Add("b", new Button(new Back(context, webShop)));
        commands.Add("q", new Button(new Quit()));
        commands.Add("quit", new Button(new Quit()));
    }
    
    public void DisplayNavigation()
    {
        for (int i = 0; i < context.GetAmountOfOptions(); i++)
        {
            Console.Write(i + 1 + "\t");
        }

        Console.WriteLine();
        for (int i = 1; i < webshop.currentChoice; i++)
        {
            Console.Write("\t");
        }

        Console.WriteLine("|");

        Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
    }

    public void LoopThroughCommands(string choice, int currentChoice)
    {
        foreach (var comm in commands)
        {
            if (commands.ContainsKey(choice) && comm.Key.Equals(choice))
            {
                comm.Value.PushButton(currentChoice);
                break;
            }
        }
        Console.WriteLine("That is not an applicable option.");
    }
}