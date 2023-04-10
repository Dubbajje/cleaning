namespace WebShopCleanCode;

public class Right : ICommand
{
    private readonly WebShop _webShop;
    private readonly MenuContext _context;
    public Right(WebShop webShop, MenuContext context)
    {
        _webShop = webShop;
        _context = context;
    }

    public void Execute(int currentChoice)
    {
        if (_webShop.currentChoice < _context.GetAmountOfOptions()) 
            _webShop.currentChoice++;
    }
}