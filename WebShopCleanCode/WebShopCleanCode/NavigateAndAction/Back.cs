namespace WebShopCleanCode;

public class Back : ICommand
{
    
    
    private MenuContext context;
    private WebShop webShop;
    public Back(MenuContext context, WebShop webShop)
    {
        this.context = context;
        this.webShop = webShop;
    }

    public void Execute(int currentChoice)
    {
        context.PreviousMenu();
        webShop.currentChoice = 1;

    }
}