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
        nextChoice.Add(1, () =>
        {
            sorting.quickSort("hej", true);
        });
    }

    public void SortOptions(int num)
    {
        switch(num)
        {
            case 1:
                quickSort("name", false);
                output.DisplayMessage("Wares sorted.");
                break;
            case 2:
                quickSort("name", true);
                output.DisplayMessage("Wares sorted.");
                break;
            case 3:
                quickSort("price", false);
                output.DisplayMessage("Wares sorted.");
                break;
            case 4:
                quickSort("price", true);
                output.DisplayMessage("Wares sorted.");
                break;
            default:
                output.DisplayMessage("Not an option.");
                break;
            
        }
        
    }

    private void quickSort(string name, bool p1)
    {
        sorting.quickSort(name, p1);
        sorting.quickSort(name, p1);
        sorting.quickSort(name, p1);
        sorting.quickSort(name, p1);
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
        Console.WriteLine("Hej");
    }
    public int GetAmountOfOptions()
    {
        return amountOfOptions;
    }

    public void PreviousMenu()
    {
        Console.WriteLine("get back");
    }

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
    
}
