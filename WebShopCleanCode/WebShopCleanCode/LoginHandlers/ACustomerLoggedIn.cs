namespace WebShopCleanCode;

public class ACustomerLoggedIn : ILoginState
{
    private LoginContext _loginContext;
    private WebShop _webShop;
    private OutputHandler _output;
    public ACustomerLoggedIn(LoginContext loginContext, WebShop webShop, OutputHandler output)
    {
        _loginContext = loginContext;
        
        _webShop = webShop;
        
        _output = output;

    }
    public void ShowCustomerLoggedIn()
    {
        Console.WriteLine("Current user: " + _webShop.currentCustomer.Username);
    }

    

    public void Login()
    {
       
    }


    public void LoginLogout()
    {
        _output.DisplayMessageWithArgument(_webShop.currentCustomer.Username, " logged out.");
        _loginContext.SetNoCustomerLoggedIn();
        _webShop.currentCustomer = null;
        _webShop.currentChoice = 1;
        

    }

    public void Purchase()
    {
        
    }

    public void SetOptions()
    {
        
    }
}