namespace WebShopCleanCode;

public class MenuContext
{
    private readonly IStateMenu _mainMenu;
    private readonly IStateMenu _waresMenu;
    private readonly IStateMenu _customerInfoMenu;
    private readonly IStateMenu _sortMenu;
    private readonly IStateMenu _loginMenu;
    private readonly IStateMenu _purchaseMenu;

    private IStateMenu _iStateMenu;
    private readonly WebShop _webshop;
    private LoginContext _loginContext;
    
    private OutputHandler _output;


    public MenuContext(WebShop webShop, Database db, OutputHandler output, LoginContext loginContext)
    {
        _webshop = webShop;
        _output = output;
        _loginContext = loginContext;
        _mainMenu = new MainMenu(this, output, _loginContext, _webshop);
        _waresMenu = new WaresMenu(this, webShop, output);
        _sortMenu = new SortMenu(this, output, db);
        _loginMenu = new LoginMenu(this, output, webShop, new LoginHandler(db, webShop, output, this, _loginContext),_loginContext);
        _purchaseMenu = new PurchaseMenu(this, db, webShop);
        _customerInfoMenu = new CustomerInfoMenu(this, output, webShop);
        _iStateMenu = _mainMenu;
        

    }

    public void SetMainMenuState()
    {
        _mainMenu.SetLoggedInOptions();
        _iStateMenu = _mainMenu;
        _webshop.currentChoice = 1;
    }

    public void SetPurchaseMenu()
    {
        if (_webshop.currentCustomer != null)
        {
            _iStateMenu = _purchaseMenu;
            //_loginContext.LoginLogOut();
            
            
        }
        _output.DisplayMessage("You must be logged in to purchase wares.");
        _webshop.currentChoice = 1;
    }

    public void SetWaresMenu()
    {
        _iStateMenu = _waresMenu;
        _webshop.currentChoice = 1;
    }

    public void SetSortMenu()
    {
        _iStateMenu = _sortMenu;
        _webshop.currentChoice = 1;
    }

    public void SetLoginMenu()
    {
        /*if (_webshop.currentCustomer != null)
        {
            _iStateMenu = _loginMenu;
            _webshop.currentChoice = 1;
        }

        
        Console.WriteLine("Nobody logged in");*/
        _iStateMenu = _loginMenu;
        _webshop.currentChoice = 1;
    }

    public void SetCustomerInfoMenu()
    {
        if (_webshop.currentCustomer == null)
        {
            Console.WriteLine("Nobody is logged in");
            return;
        }
        _iStateMenu = _customerInfoMenu;
    }

    public void DisplayMenu()
    {
        _iStateMenu.DisplayMenu();
        
    }

    public IStateMenu GetContext()
    {
        return _iStateMenu;
    }

    public void DisplayInfo()
    {
        _iStateMenu.DisplayInfo();
    }

    public int GetAmountOfOptions()
    {
        return _iStateMenu.GetAmountOfOptions();
    }

    public void PreviousMenu()
    {
        _iStateMenu.PreviousMenu();
        
    }

}