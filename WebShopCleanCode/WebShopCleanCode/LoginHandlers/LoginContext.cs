namespace WebShopCleanCode;

public class LoginContext
{
    ILoginState loggedIn;
    ILoginState notLoggedIn;
    ILoginState iLoginState;
    private WebShop webShop;
    private Customer currentCustomer;
    
    


    public LoginContext(WebShop webShop)
    {
        this.webShop = webShop;
        currentCustomer = null;
        loggedIn = new ACustomerLoggedIn(this, this.webShop, new OutputHandler());
        notLoggedIn = new NoCustomerLoggedIn(this, new OutputHandler());
        
        
        iLoginState = notLoggedIn;
        
    }

    public void setLoggedInState(ILoginState newLoginState)
    {
        iLoginState = newLoginState;
    }

    public void SetLoggedIn()
    {
        iLoginState = loggedIn;
    }

    public void SetNoCustomerLoggedIn()
    {
        iLoginState = notLoggedIn;
    }
    public void ShowCustomerLoggedIn()
    {
        iLoginState.ShowCustomerLoggedIn();
    }

    public void LoginLogOut()
    {
        iLoginState.LoginLogout();
    }
    

    public void SetOptions()
    {
        
    }
    
}