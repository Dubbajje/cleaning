namespace WebShopCleanCode;

public class CustomerBuilder
{
    private string username ="";
    private string password = "";
    private string firstName = "";
    private string lastName = "";
    private string email = "";
    private int age = 0;
    private string address = "";
    private string phoneNumber = "";
    private int funds = 0;

    public CustomerBuilder SetUsername(string username)
    {
        this.username = username;
        return this;
    }

    public CustomerBuilder SetPassword(string password)
    {
        this.password = password;
        return this;
    }
    public CustomerBuilder SetFirstname(string firstname)
    {
        this.firstName = firstname;
        return this;
    }
    public CustomerBuilder SetLastname(string lastname)
    {
        this.lastName = lastname;
        return this;
    }
    public CustomerBuilder SetEmail(string email)
    {
        this.email = email;
        return this;

    }
    public CustomerBuilder SetAge(int age)
    {
        this.age = age;
        return this;
    }
    public CustomerBuilder SetAddress(string address)
    {
        this.address = address;
        return this;
    }

    public CustomerBuilder SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
        return this;
    }

    public CustomerBuilder SetFunds(int funds)
    {
        this.funds = funds;
        return this;
    }
}