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
        public List<Product> Products { get; set; }
        public List<Customer> Customers;
        
        private MenuContext context;
        private Navigation navigation;
        private LoginContext _loginContext;
        public Customer CurrentCustomer { get; set; }
        public int CurrentChoice;
        

        public WebShop(OutputHandler outputHandler, Database database)
        {
            CurrentChoice = 1;
            CurrentCustomer = null;
            Products = database.GetProducts();
            Customers = database.GetCustomers();
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
                string choice = Console.ReadLine().ToLower();
                navigation.LoopThroughCommands(choice, CurrentChoice);
            }
        }
    }
}