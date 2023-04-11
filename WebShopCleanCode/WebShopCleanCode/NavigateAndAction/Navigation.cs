using System.ComponentModel.Design;

namespace WebShopCleanCode;

public class Navigation
{
    private readonly Dictionary<string, Button> _commands;
    private readonly MenuContext _context;
    private readonly WebShop _webShop;
    

    public Navigation(MenuContext context, WebShop webShop)
    {
        _commands = new Dictionary<string, Button>();
        _context = context;
        _webShop = webShop;
        _commands.Add("l", new Button(new Left(webShop)));
        _commands.Add("left", new Button(new Left(webShop)));
        _commands.Add("r", new Button(new Right(webShop, context)));
        _commands.Add("right", new Button(new Right(webShop, context)));
        _commands.Add("ok", new Button(new Okay(context)));
        _commands.Add("o", new Button(new Okay(context)));
        _commands.Add("k", new Button(new Okay(context)));
        _commands.Add("okay", new Button(new Okay(context)));
        _commands.Add("back", new Button(new Back(context, webShop)));
        _commands.Add("b", new Button(new Back(context, webShop)));
        _commands.Add("q", new Button(new Quit()));
        _commands.Add("quit", new Button(new Quit()));
    }
    
    public void DisplayNavigation()
    {
        for (int i = 0; i < _context.GetAmountOfOptions(); i++)
        {
            Console.Write(i + 1 + "\t");
        }
        Console.WriteLine();
        for (int i = 1; i < _webShop.CurrentChoice; i++)
        {
            Console.Write("\t");
        }
        Console.WriteLine("|");

        Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");
    }

    public void LoopThroughCommands(string choice, int currentChoice)
    {
        foreach (var comm in _commands)
        {
            if (_commands.ContainsKey(choice) && comm.Key.Equals(choice))
            {
                comm.Value.PushButton(currentChoice);
                return;
            }
        }
        Console.WriteLine("That is not an applicable option.");
    }
}