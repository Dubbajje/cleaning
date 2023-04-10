using System.Runtime.Loader;

namespace WebShopCleanCode;

public class WaresMenu : IStateMenu
{
    public delegate void OptionDelegate();
    private Dictionary<int, OptionDelegate> nextChoice;
    private MenuContext context;
    
    private WebShop webShop;
    private List<string> options;
    string info;
    private int amountOfOptions;
    private OutputHandler output;
    public WaresMenu(MenuContext context, WebShop webShop, OutputHandler output)
    {
        amountOfOptions = 4;
        this.context = context;
        this.webShop = webShop;
        
        this.output = output;
        options = new List<string>();
        options.Add("See all wares");
        options.Add("Purchase a ware");
        options.Add("Sort wares");
        options.Add("Login");
        //logout
        info = "What would you like to do?";
        nextChoice = new Dictionary<int, OptionDelegate>();
        nextChoice.Add(1, () => PrintEveryProduct());
        nextChoice.Add(2, () => context.SetPurchaseMenu() );
        nextChoice.Add(3, () => { context.SetSortMenu(); });
        nextChoice.Add(4, () => { context.SetLoginMenu(); });
    }
    
    
    public void DisplayMenu()
    { 
        for (int i = 0; i < options.Count-1; i++)
        {
            Console.WriteLine(i+1 + ": " + options[i]);
        }

        if (webShop.currentCustomer == null)
        {
            Console.WriteLine("4: Login");
        }
        else
        {
            Console.WriteLine("4: Logout");
        }
    }

    private void PrintEveryProduct()
    {
        foreach (Product product in webShop.products)
        {
            product.PrintInfo();
        }
    }
    
    public void Execute(int currentChoice)
    {
        foreach (var option in nextChoice)
        {
            if (option.Key == currentChoice )
            {
                option.Value();
                return;
            }
        }
        output.DisplayMessage("Not an option.");
    }
    public int GetAmountOfOptions()
    {
        return amountOfOptions;
    }

    public void PreviousMenu()
    {
        context.SetMainMenuState();
    }

    public void SetLoggedInOptions()
    {
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
    
    
}