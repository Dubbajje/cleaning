using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode
{
    public class WebShop
    {
        bool running = true;
        private Database database;
        public List<Product> products { get; set; } = new List<Product>();
        public List<Customer> customers = new List<Customer>();
        private OutputHandler outputHandler;
        private MenuContext context;
        private Navigation navigation;
        private LoginContext _loginContext;


        public Customer currentCustomer { get; set; }
        public int currentChoice;
        


        public WebShop(OutputHandler outputHandler, Database database)
        {
            currentChoice = 1;
            currentCustomer = null;
            products = database.GetProducts();
            customers = database.GetCustomers();
            this.outputHandler = outputHandler;
            _loginContext = new LoginContext(this);
            context = new MenuContext(this, database, outputHandler, _loginContext);
            navigation = new Navigation(context, this);
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");

            while (running)
            {
                context.DisplayInfo();
                context.DisplayMenu();
                navigation.DisplayNavigation();
                _loginContext.ShowCustomerLoggedIn();
                string Choice = Console.ReadLine().ToLower();
                navigation.LoopThroughCommands(Choice, currentChoice);
                
            }
        }
    }
}