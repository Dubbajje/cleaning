namespace WebShopCleanCode;

public class Register
{
    private string userName;
    private string password;
    private string newPassword;
    private string firstName;
    private string lastName;
    private string email;
    private int age;
    private string address;
    private string phoneNumber;
    private OutputHandler output;
    private WebShop _webShop;
    private LoginContext _loginContext;
    private MenuContext _menuContext;

    public Register(OutputHandler output, WebShop webShop, LoginContext logincontext, MenuContext context)
    {
        this.output = output;
        _webShop = webShop;
        _loginContext = logincontext;
        _menuContext = context;
    }

    public void CreateCustomer()
    {
        CustomerBuilder customerBuilder = new CustomerBuilder();
        Customer newCustomer = customerBuilder.SetUsername(userName).SetPassword(password)
            .SetFirstname(firstName).SetLastname(lastName).SetEmail(email).SetAge(age).SetAddress(address)
            .SetPhoneNumber(phoneNumber)
            .Build();
        _webShop.customers.Add(newCustomer);
        _webShop.currentCustomer = newCustomer;
        Console.WriteLine(newCustomer.Username);
        output.DisplayMessageWithArgument(newCustomer.Username, " successfully added and is now logged in.");
        SetLoggedInContexts();
        //Spara i databasen
    }

    public void SetLoggedInContexts()
    {
        _loginContext.SetLoggedIn();
        _menuContext.SetMainMenuState();
    }

    public void EnterUsername() //login op4
    {
        Console.WriteLine("Please write your username.");
        userName = Console.ReadLine();
        foreach (Customer customer in _webShop.customers)
        {
            if (customer.Username.Equals(userName))
            {
                output.DisplayMessage("Username already exists.");
                return;
            }
        }
        // Would have liked to be able to quit at any time in here.

    }

    public void RegistrerAllInformation()
    {
        EnterUsername();
        password = RegistrerUserInformation("a password", "password");
        firstName = RegistrerUserInformation("a first name", "first name");
        lastName = RegistrerUserInformation("a last name", "last name");
        age = DoYouWantAge();
        email = RegistrerUserInformation("an email", "email");
        address = RegistrerUserInformation("an address", "address");
        phoneNumber = RegistrerUserInformation("a phone number", "phone number");
        CreateCustomer();

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
                        age = int.Parse(ageString);
                        return age;
                    }
                    catch (FormatException e)
                    {
                        output.DisplayMessage("Please write a number.");
                        continue;
                    }
                }
            }

            if (choice.Equals("n"))
            {
                return -1;
            }

            output.DisplayMessage("y or n, please.");
        }
    }


    private string RegistrerUserInformation(String questionYN, string question)
    {
        string choice;
        string userInformation;
        while (true)
        {
            Console.WriteLine("Do you want " + questionYN + "? y/n");
            choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                while (true)
                {
                    Console.WriteLine("Please write your " + question + ".");
                    userInformation = Console.ReadLine();
                    if (userInformation.Equals(null))
                    {
                        output.DisplayMessage("Please actually write something.");
                        continue;
                    }

                    return userInformation;
                }

            }

            if (choice.Equals("n"))
            {
                return null;
            }

            output.DisplayMessage("y or n, please.");

        }
    }


}

