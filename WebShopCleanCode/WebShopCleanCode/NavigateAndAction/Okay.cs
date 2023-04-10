namespace WebShopCleanCode;

public class Okay : ICommand
{
    private readonly MenuContext _context;
    private IStateMenu _iStateMenu;

    public Okay(MenuContext context)
    {
        _context = context;
    }
    public void Execute(int currentChoice)
    {
        _iStateMenu  = _context.GetContext();
        _iStateMenu.Execute(currentChoice);

    }
}