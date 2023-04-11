using System.Threading.Channels;

namespace WebShopCleanCode;

public class CustomerInfoMenu : IStateMenu
{
    readonly MenuContext _context;
    private List<string> Options { get;}
    private delegate void OptionDelegate();
    private readonly Dictionary<int, OptionDelegate> _nextChoice;
    private readonly string _info;
    private int AmountOfOptions { get;}
    private readonly OutputHandler _output;
    private WebShop _webShop;
    public CustomerInfoMenu(MenuContext context, OutputHandler output, WebShop webShop)
    {   
        _context = context;
        _output = output;
        _webShop = webShop;
        AmountOfOptions = 3;
        _info = "What would you like to do?";
        FundsHandler funds = new FundsHandler(output, webShop);
        
        Options = new List<string>();
        string option2 = "See your info";
        string option3 = "Add funds";
        string option1 = "See your orders";
        
        
        Options.Add(option1);
        Options.Add(option2);
        Options.Add(option3);
        
        
        _nextChoice = new Dictionary<int, OptionDelegate>();
        _nextChoice.Add(1, PrintOrders );
        _nextChoice.Add(2, PrintInfo );
        _nextChoice.Add(3, funds.AddFunds);

    }

    private void PrintOrders()
    {
        _webShop.CurrentCustomer.PrintOrders();

    }

    private void PrintInfo()
    {
        _webShop.CurrentCustomer.PrintInfo();
    }

    public void DisplayMenu()
    {
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine(i+1 + ": " + Options[i]);
        }
    }
    public int GetAmountOfOptions()
    {
        return AmountOfOptions;
    }

    public void PreviousMenu()
    {
        _context.SetMainMenuState();
    }

    public void SetLoggedInOptions()
    {
        
    }

    public void Execute(int currentChoice)
    {
        foreach (var option in _nextChoice)
        {
            if (option.Key == currentChoice )
            {
                option.Value();
                return;
            }
        }
        _output.DisplayMessage("Not an option.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine(_info);
    }
}