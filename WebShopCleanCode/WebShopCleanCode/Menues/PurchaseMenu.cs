using System.Runtime.Loader;

namespace WebShopCleanCode;

public class PurchaseMenu : IStateMenu
{
    public delegate void OptionDelegate();

    private readonly Dictionary<int, OptionDelegate> _nextChoice;
    private readonly string _info;
    public List<string> Options { get; set; }
    private readonly MenuContext _context;
    private List<Product> _products;
    private Database _db;
    private int AmountOfOptions { get; set; }
    private Customer _currentCustomer;
    private WebShop _webShop;
    private PurchaseHandler _purchaseHandler;
    public PurchaseMenu(MenuContext context, Database db, WebShop webShop)
    {
        _nextChoice = new Dictionary<int, OptionDelegate>();
        _context = context;
        _db = db;
        _products = db.GetProducts();
        string option1 = "See all wares";
        string option3 = "Sort wares";
        string option4 = "Login";
        string option2 = "Purchase a ware";
        _info = "What would you like to purchase?";
        _webShop = webShop;
        _purchaseHandler = new PurchaseHandler(_webShop, _db, new OutputHandler());
        
        
        
        Options = new List<string>
        {
            option1,
            option2,
            option3,
            option4
        };
    }
    
    public int GetAmountOfOptions()
    {
        return AmountOfOptions;
    }

    public void PreviousMenu()
    {
        _context.SetWaresMenu();
    }

    public void SetLoggedInOptions()
    {
        Options[3] = "Logout";
        
    }
    

    public void DisplayMenu()
    {
        AmountOfOptions = _products.Count;
        for (int i = 0; i < AmountOfOptions; i++)
        {
            Console.WriteLine(i + 1 + ": " + _products[i].Name + ", " + _products[i].Price + "kr");
        }

        Console.WriteLine("Your funds: " + _webShop.currentCustomer.Funds);
    }

    public void Execute(int currentChoice)
    {
        _purchaseHandler.Purchase();
    }

    public void DisplayInfo()
    {
        Console.WriteLine(_info);
    }
}