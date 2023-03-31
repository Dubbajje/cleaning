using System.Threading.Channels;

namespace WebShopCleanCode;

public class CustomerInfoMenu : IStateMenu
{
    MenuContext context;
    List<string> options;
    public delegate void OptionDelegate();
    public Dictionary<int, OptionDelegate> nextChoice;
    private string info;
    public int amountOfOptions;
    public CustomerInfoMenu(MenuContext context)
    {
        string option2 = "Set your info";
        string option3 = "Add funds";
        string option1 = "See your orders";
        this.amountOfOptions = 3;
        info = "What would you like to do?";
        options = new List<string>();
        options.Add(option1);
        options.Add(option2);
        options.Add(option3);
        this.context = context;
        
        nextChoice = new Dictionary<int, OptionDelegate>();
        nextChoice.Add(1, () => context.setWaresMenu());
        nextChoice.Add(2, () => { Console.WriteLine("ny meny"); });
        nextChoice.Add(3, () => { Console.WriteLine("nya meny"); });
    }

    public void DisplayMenu()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine(i+1 + ": " + options[i]);
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

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
}