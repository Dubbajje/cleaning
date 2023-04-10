namespace WebShopCleanCode;

public class MainMenu : IStateMenu
{
    MenuContext _context;
    private LoginContext _loginContext;
    private List<string> Options { get; set; }
    private readonly OutputHandler _output;

    private delegate void OptionDelegate();
    private int AmountOfOptions { get; set; }
    
    
    private readonly Dictionary<int, OptionDelegate> _nextChoice;
    private readonly string _info;
    private WebShop _webShop;
    public MainMenu(MenuContext context, OutputHandler output, LoginContext loginContext, WebShop webShop) 
    {
        AmountOfOptions = 3;
        _info = "What would you like to do?";
        _context = context;
        this._output = output;
        _loginContext = loginContext;
        _webShop = webShop;
        Options = new List<string>
        {
            "See Wares",
            "Customer Info",
            "Login"
        };
        _nextChoice = new Dictionary<int, OptionDelegate>
        {
            { 1, context.SetWaresMenu },
            { 2, context.SetCustomerInfoMenu },
            { 3, context.SetLoginMenu }
        };
    }

    public void SetLoggedInOptions()
    {
        if (_webShop.currentCustomer != null)
        {
            Options[2] = "Logout";
            _nextChoice[3] = () =>
            {
                _loginContext.LoginLogOut();
                SetLoggedOutOptions();
            };

        }
    }

    public void SetLoggedOutOptions()
    {
        Options[2] = "Login";
        _nextChoice[3] = _context.SetLoginMenu;
    }
    

    public void DisplayMenu()
    {
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine(i+1 + ": " + Options[i]);
        }
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
    public int GetAmountOfOptions()
    {
        return AmountOfOptions;
    }

    public void PreviousMenu()
    {
        _output.DisplayMessage("You're already on the main menu.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine(_info);
    }
}