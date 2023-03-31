namespace WebShopCleanCode;

public class Okey : ICommand
{
    Navigation navigation;
    MenuContext context;
    IStateMenu iStateMenu;

    public Okey(Navigation navigation, MenuContext context)
    {
        this.navigation = navigation;
        this.context = context;

    }
    public void Execute(int currentChoice)
    {
        iStateMenu  = context.GetContext();
        iStateMenu.Execute(currentChoice);

    }
}