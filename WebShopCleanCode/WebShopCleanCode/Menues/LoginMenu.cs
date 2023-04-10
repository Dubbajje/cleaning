namespace WebShopCleanCode;

public class LoginMenu : IStateMenu
{
    readonly MenuContext _context;
    private readonly List<string> _options;

    private delegate void OptionDelegate();
    private readonly Dictionary<int, OptionDelegate> _nextChoice;
    private string Info { get; }
    private readonly OutputHandler _output;
    private WebShop _webShop;
    private int AmountOfOptions { get; }
    private LoginHandler _loginHandler;
    private Register _register;
    public LoginMenu(MenuContext context, OutputHandler output, WebShop webShop, LoginHandler login, LoginContext loginContext)
    {

        AmountOfOptions = 4;
        _webShop = webShop;
        _output = output;
        Info = "Please submit username and password.";
        _context = context;
        _loginHandler = login;
        _register = new Register(output, _webShop, loginContext, context);
        _options = new List<string>
        
        {
            "Set Username",
            "Set Password",
            "Login",
            "Register"
        };
        _nextChoice = new Dictionary<int, OptionDelegate>
        {
            
            {1, _loginHandler.SetUsername},
            {2, _loginHandler.SetPassword},
            {3, _loginHandler.Login},
            {4, _register.RegistrerAllInformation}

        };

    }

    public void DisplayMenu()
    {
        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine(i+1 + ": " + _options[i]);
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
        _context.SetMainMenuState();
    }

    public void SetLoggedInOptions()
    {
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine(Info);
    }
    
    
    
    
}