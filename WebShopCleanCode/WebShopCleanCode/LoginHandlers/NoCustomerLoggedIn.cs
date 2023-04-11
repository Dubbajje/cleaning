namespace WebShopCleanCode;

public class NoCustomerLoggedIn : ILoginState
{
    private LoginContext context;
    private OutputHandler output;

    public NoCustomerLoggedIn(LoginContext context, OutputHandler output)
    {
        this.context = context;
        this.output = output;
    }
    public void ShowCustomerLoggedIn()
    {
        Console.WriteLine("Nobody logged in.");
    }

    public void LoginLogout()
    {
        context.SetOptions();
    }
    
    public void Purchase()
    {
        output.DisplayMessage("You must be logged in to purchase wares.");

    }
}
    