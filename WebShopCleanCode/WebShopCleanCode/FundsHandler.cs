namespace WebShopCleanCode;

public class FundsHandler
{
    private WebShop _webShop;
    private OutputHandler _output;
    
    public FundsHandler(OutputHandler output, WebShop webShop)
    {
        _output = output;
        _webShop = webShop;
    }

    public void AddFunds()
    {
        Console.WriteLine("How many funds would you like to add?");
        string amountString = Console.ReadLine();
        try
        {
            int amount = int.Parse(amountString);
            if (amount < 0)
            {
                _output.DisplayMessage("Don't add negative amounts.");
            }
            else
            {
                _webShop.currentCustomer.Funds += amount;
                _output.DisplayMessageWithArgument(amountString, " added to your profile.");
            }
        }
        catch (FormatException e)
        {
            _output.DisplayMessage("Please write a number next time.");
        }
    }
}