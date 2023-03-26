namespace WebShopCleanCode;

public class Left : ICommand
{
    Navigation navigation;
    public Left(Navigation navigation)
    {
        this.navigation = navigation;
    }

    public void Execute()
    {
        if(navigation.currentChoice > 1) 
            navigation.currentChoice--;
    }
}