namespace WebShopCleanCode;

public class Left : ICommand
{
    private readonly WebShop _webShop;
    public Left(WebShop webShop)
    {
        _webShop = webShop;
    }

    public void Execute(int currentChoice)
    {
        if(_webShop.currentChoice > 1) 
            _webShop.currentChoice--;
    }
}