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


    /* if (currentCustomer != null)
    {
        currentMenu = "purchase menu";
        info = "What would you like to purchase?";
        currentChoice = 1;
        amountOfOptions = products.Count;
    }*/

    public void Login()
    {
        
    }

    public void Purchase()
    {
        output.DisplayMessage("You must be logged in to purchase wares.");

    }

    public void SetOptions()
    {
        
    }
}