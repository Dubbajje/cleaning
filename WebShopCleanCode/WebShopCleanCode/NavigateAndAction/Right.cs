namespace WebShopCleanCode;

public class Right : ICommand
{
    Navigation navigation;
    private WebShop webShop;
    private MenuContext context;
    public Right(Navigation navigation, WebShop webShop, MenuContext context)
    {
        this.navigation = navigation;
        this.webShop = webShop;
        this.context = context;
    }

    public void Execute(int currentChoice)
    {
        if (webShop.currentChoice < context.GetAmountOfOptions()) 
            webShop.currentChoice++;
    }
}