namespace WebShopCleanCode;

public class PurchaseMenu : IStateMenu
{
    public delegate void OptionDelegate();
    public Dictionary<int, OptionDelegate> nextChoice;
    private string info;
    private List<string> options;
    public int amountOfOptions { get; set; }
    public PurchaseMenu(MenuContext context)
    {
        string option1 = "See all wares";
        string option3 = "Sort wares";
        string option4 = "Beroende på inloggad kund - login och logout";
        string option2 = "Purchase a ware";
        info = "Kolla upp detta";
        options = new List<string>();
        options.Add(option1);
        options.Add(option2);
        options.Add(option3);
        options.Add(option4);
    }
    public int GetAmountOfOptions()
    {
        return amountOfOptions;
    }

    public void PreviousMenu()
    {
        Console.WriteLine("get back");
    }

    public void ShowProducts()
    {/*
        for (int i = 0; i < amountOfOptions; i++)
        {
            Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
        }

        Console.WriteLine("Your funds: " + currentCustomer.Funds);*/
    }

    public void Engrej()
    {/*
        int index = currentChoice - 1;
        Product product = products[index];
        if (product.InStock())
        {
            if (currentCustomer.CanAfford(product.Price))
            {
                currentCustomer.Funds -= product.Price;
                product.NrInStock--;
                currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                outputHandler.DisplayMessageWithArgument("Successfully bought ", product.Name);
            }
            else
            {
                outputHandler.DisplayMessage("You cannot afford.");
            }
        }
        else
        {
            outputHandler.DisplayMessage("Not in stock.");
        }*/
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

    public void DisplayInfo()
    {
        Console.WriteLine(info);
    }
}