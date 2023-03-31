namespace WebShopCleanCode;

public class MenuContext
{
    IStateMenu mainMenu;
    IStateMenu waresMenu;
    IStateMenu customerInfoMenu;
    IStateMenu sortMenu;
    IStateMenu loginMenu;
    IStateMenu purchaseMenu;

    IStateMenu iStateMenu;
    private WebShop webshop;
    private Database db;
    
    
    public MenuContext(WebShop webShop, Database db)
    {
        this.webshop = webShop;
        db = db;
        mainMenu = new MainMenu(this);
        waresMenu = new WaresMenu(this, webShop);
        sortMenu = new SortMenu(this,new OutputHandler(), db );
        loginMenu = new LoginMenu(this);
        purchaseMenu = new PurchaseMenu(this);
        customerInfoMenu = new CustomerInfoMenu(this);
        this.iStateMenu = mainMenu;
        
    }

    public void setMenuState(IStateMenu newState)
    {
        iStateMenu = newState;
    }

    public void setMainMenuState()
    {
        iStateMenu = mainMenu;
    }

    public void setPurchaseMenu()
    {
        iStateMenu = purchaseMenu;
    }

    public void setWaresMenu()
    {
        iStateMenu = waresMenu;
    }

    public void setSortMenu()
    {
        iStateMenu = sortMenu;
    }
    public void setLoginMenu()
    {
        iStateMenu = loginMenu;
    }

    public void setCustomerInfoMenu()
    {
        if (webshop.currentCustomer == null)
        {
            Console.WriteLine("Nobody is logged in");
        }
        iStateMenu = customerInfoMenu;
    }
    public void DisplayMenu()
    {
        iStateMenu.DisplayMenu();
    }

    public IStateMenu GetContext()
    {
        return iStateMenu;
    }

    public void DisplayInfo()
    {
        iStateMenu.DisplayInfo();
    }

    public int GetAmountOfOptions()
    {
        return iStateMenu.GetAmountOfOptions();
    }

    public void PreviousMenu()
    {
        iStateMenu.PreviousMenu();
    }
    


}