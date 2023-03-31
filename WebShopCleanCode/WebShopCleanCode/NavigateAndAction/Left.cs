namespace WebShopCleanCode;

public class Left : ICommand
{
    Navigation navigation;
    private WebShop webshop;
    public Left(Navigation navigation, WebShop webShop)
    {
        this.navigation = navigation;
        this.webshop = webShop;
    }

    public void Execute(int currentChoice)
    {
        if(webshop.currentChoice > 1) 
            webshop.currentChoice--;
    }
}