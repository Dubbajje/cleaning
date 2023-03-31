namespace WebShopCleanCode;

public class LoginMenu : IStateMenu
{
    MenuContext context;
    List<string> options;
    public delegate void OptionDelegate();
    public Dictionary<int, OptionDelegate> nextChoice;
    private string info;
    public int amountOfOptions { get; set; }
    public LoginMenu(MenuContext context)
    {
        
        
        //om costumer är null
        string option1 = "Set Username";
        string option2 = "Set Password";
        string option3 = "Login";
        string option4 = "Register";
        amountOfOptions = 4;
        info = "Please submit username and password.";
        this.context = context;
        options = new List<string>();
        options.Add(option1);
        options.Add(option2);
        options.Add(option3);
        options.Add(option4);
        nextChoice = new Dictionary<int, OptionDelegate>();
        nextChoice.Add(1, () => context.setWaresMenu());
        nextChoice.Add(2, () => context.setCustomerInfoMenu());

        //om customer inte är null
        option4 = "Login";
        //outputHandler.DisplayMessageWithArgument(currentCustomer.Username," logged out." );
        //currentCustomer = null;
        
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
        context.setMainMenuState();
    }

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
}