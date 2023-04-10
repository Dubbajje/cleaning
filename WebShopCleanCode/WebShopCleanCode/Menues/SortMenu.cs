namespace WebShopCleanCode;

public class SortMenu : IStateMenu
{
    public delegate void OptionDelegate();

    public int amountOfOptions { get; set; }
    private string info;
    private List<string> options;
    private MenuContext context;
    public Dictionary<int, OptionDelegate> nextChoice;
    private OutputHandler output;
    public Database db;
    private Sorting sorting;


    public SortMenu(MenuContext context, OutputHandler output, Database db)
    {
        string option1 = "Sort by name, descending";
        string option2 = "Sort by name, ascending";
        string option3 = "Sort by price, descending";
        string option4 = "Sort by price, ascending";
        info = "How would you like to sort them?";

        this.db = db;
        sorting = new Sorting(db);
        this.output = output;
        amountOfOptions = 4;
        options = new List<string>();
        options.Add(option1);
        options.Add(option2);
        options.Add(option3);
        options.Add(option4);
        nextChoice = new Dictionary<int, OptionDelegate>();
        this.context = context;
        nextChoice.Add(1, () => { sorting.MergeSortByName(false); });
        nextChoice.Add(2, () => { sorting.MergeSortByName(true); });
        nextChoice.Add(3, () => { sorting.MergeSortByPrice(true); });
        nextChoice.Add(4, () => { sorting.MergeSortByPrice(false); });
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
                output.DisplayMessage("Wares sorted");
                PreviousMenu();
                return;
            }
        }
        output.DisplayMessage("Not an option.");
        
    }
    public int GetAmountOfOptions()
    {
        return amountOfOptions;
    }

    public void PreviousMenu()
    {
        context.SetWaresMenu();
    }

    public void SetLoggedInOptions()
    {
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }

}
