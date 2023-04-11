namespace WebShopCleanCode;

public class Register
{
    private string _userName;
    private string _password;
    private string _firstName;
    private string _lastName;
    private string _email;
    private int _age;
    private string _address;
    private string _phoneNumber;
    private OutputHandler _output;
    private readonly WebShop _webShop;
    private readonly LoginContext _loginContext;
    private readonly MenuContext _menuContext;

    public Register(OutputHandler output, WebShop webShop, LoginContext logincontext, MenuContext context)
    {
        _output = output;
        _webShop = webShop;
        _loginContext = logincontext;
        _menuContext = context;
    }

    public void CreateCustomer()
    {
        CustomerBuilder customerBuilder = new CustomerBuilder();
        Customer newCustomer = customerBuilder.SetUsername(_userName).SetPassword(_password)
            .SetFirstname(_firstName).SetLastname(_lastName).SetEmail(_email).SetAge(_age).SetAddress(_address)
            .SetPhoneNumber(_phoneNumber)
            .Build();
        _webShop.Customers.Add(newCustomer);
        _webShop.CurrentCustomer = newCustomer;
        Console.WriteLine(newCustomer.Username);
        _output.DisplayMessageWithArgument(newCustomer.Username, " successfully added and is now logged in.");
        SetLoggedInContexts();
        
    }

    private void SetLoggedInContexts()
    {
        _loginContext.SetLoggedIn();
        _menuContext.SetMainMenuState();
    }

    public bool DoesUsernameExist()
    {
        bool validUsername;
        
        Console.WriteLine("Please write your username.");
        _userName = Console.ReadLine();
        foreach (Customer customer in _webShop.Customers)
        {
            if (customer.Username.Equals(_userName))
            {
                _output.DisplayMessage("Username already exists.");
                validUsername = false;
                return validUsername;
            }
        }
        validUsername = true;
        return validUsername;
        // Would have liked to be able to quit at any time in here.

    }

    public void RegistrerAllInformation()
    {
        bool CanCreateACustomer = DoesUsernameExist();
        if (CanCreateACustomer)
        {
            _password = RegisterUserInformation("a password", "password");
            _firstName = RegisterUserInformation("a first name", "first name");
            _lastName = RegisterUserInformation("a last name", "last name");
            _age = DoYouWantAge();
            _email = RegisterUserInformation("an email", "email");
            _address = RegisterUserInformation("an address", "address");
            _phoneNumber = RegisterUserInformation("a phone number", "phone number");
            CreateCustomer();
        }

    }

    private int DoYouWantAge()
    {
        string choice;
        while (true)
        {
            Console.WriteLine("Do you want an age? y/n");
            choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                while (true)
                {
                    Console.WriteLine("Please write your age.");
                    string ageString = Console.ReadLine();
                    try
                    {
                        _age = int.Parse(ageString);
                        return _age;
                    }
                    catch (FormatException e)
                    {
                        _output.DisplayMessage("Please write a number.");
                        
                    }
                }
            }

            if (choice.Equals("n"))
            {
                return -1;
            }

            _output.DisplayMessage("y or n, please.");
        }
    }


    private string RegisterUserInformation(String indefiniteVariable, string variable)
    {
        string choice;
        string userInformation;
        while (true)
        {
            Console.WriteLine("Do you want " + indefiniteVariable + "? y/n");
            choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                while (true)
                {
                    Console.WriteLine("Please write your " + variable + ".");
                    userInformation = Console.ReadLine();
                    if (userInformation.Equals(""))
                    {
                        _output.DisplayMessage("Please actually write something.");
                        continue;
                    }
                    return userInformation;
                }

            }

            if (choice.Equals("n"))
            {
                return null;
            }

            _output.DisplayMessage("y or n, please.");

        }
    }
}

