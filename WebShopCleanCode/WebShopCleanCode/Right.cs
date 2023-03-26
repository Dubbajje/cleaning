namespace WebShopCleanCode;

public class Right : ICommand
{
    Navigation navigation;
    public Right(Navigation navigation)
    {
        this.navigation = navigation;
    }
    
    public void Execute()
    {
        if (navigation.currentChoice < navigation.amountOfOptions) 
            navigation.currentChoice++;
    }
}