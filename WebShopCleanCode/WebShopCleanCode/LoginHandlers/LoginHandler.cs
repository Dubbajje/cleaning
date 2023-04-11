using System.Security.AccessControl;

namespace WebShopCleanCode;

public class LoginHandler
{
    private Database db;
    string username;
    string password;
    private List<Customer> customers;
    private WebShop webShop;
    private OutputHandler output;
    private MenuContext _context;
    private LoginContext _loginContext;
    
    
    public LoginHandler(Database db, WebShop webShop, OutputHandler output, MenuContext context, LoginContext logincontext)
    {
        this.db = db;
        this.webShop = webShop;
        _context = context;
        username = null;
        password = null;
        customers = db.GetCustomers();
        this.output = output;
        _loginContext = logincontext;

    }

    public string ReadCustomerInfo(string variable)
    {
        Console.WriteLine("A keyboard appears.");
        Console.WriteLine("Please input your " + variable +".");
        string customerInfo = Console.ReadLine();
        Console.WriteLine();
        return customerInfo;

    }
    
    public void SetPassword()
    {
        password = ReadCustomerInfo("password");
    }

    public void SetUsername()
    {
        username = ReadCustomerInfo("username");
    }

    private bool IsIncompleteData()
    {
        if (username == null || password == null)
        {
            output.DisplayMessage("Incomplete data.");
            return true;
        }
        return false;
    }
    public void Login()
    {
        if (IsIncompleteData())
            return;
        {
            bool found = false;
            foreach (Customer customer in customers)
            {
                if (username.Equals(customer.Username) && customer.CheckPassword(password))
                {
                    output.DisplayMessageWithArgument(customer.Username, " logged in.");
                    webShop.CurrentCustomer = customer;
                    found = true;
                    _loginContext.SetLoggedIn();
                    _context.SetMainMenuState();
                }
            }

            if (found == false)
            {
                output.DisplayMessage("Invalid credentials.");
            }
        }
    }
}