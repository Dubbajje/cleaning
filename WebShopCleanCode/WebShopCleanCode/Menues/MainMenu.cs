namespace WebShopCleanCode;

public class MainMenu : IStateMenu
{
    MenuContext context;
    List<string> options;
    public delegate void OptionDelegate();
    public int amountOfOptions { get; set; }
    
    
    public Dictionary<int, OptionDelegate> nextChoice;
    private string info;
    public MainMenu(MenuContext context) 
    {
        amountOfOptions = 3;
        info = "What would you like to do?";
        this.context = context;
        options = new List<string>();
        options.Add("See Wares");
        options.Add("Customer Info");
        options.Add("Login");
        nextChoice = new Dictionary<int, OptionDelegate>();
        nextChoice.Add(1, () => context.setWaresMenu());
        nextChoice.Add(2, () => context.setCustomerInfoMenu());
        nextChoice.Add(3, () => context.setLoginMenu());

    }

    public void DisplayMenu()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine(i+1 + ": " + options[i]);
        }
    }

    public void Execute(int currentChoice)
    {
        foreach (var option in nextChoice)
        {
            if (option.Key == currentChoice )
            {
                option.Value();
            }
            
        }
    }
    public int GetAmountOfOptions()
    {
        return amountOfOptions;
    }

    public void PreviousMenu()
    {
        Console.WriteLine("You are already here");
    }

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
}