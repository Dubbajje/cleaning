namespace WebShopCleanCode;

public class Back : ICommand
{
    private readonly MenuContext _context;
    private readonly WebShop _webShop;
    public Back(MenuContext context, WebShop webShop)
    {
        _context = context;
        _webShop = webShop;
    }

    public void Execute(int currentChoice)
    {
        _context.PreviousMenu();
        _webShop.currentChoice = 1;
    }
}