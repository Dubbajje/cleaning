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
        List<Customer> customers = new List<Customer>();
        private OutputHandler outputHandler;
        private MenuContext context;

        private Navigation navigation;
        private CustomerBuilder customerBuilder;
        string username = null;
        string password = null;
        public Customer currentCustomer { get; set; }
        public int currentChoice;


        public WebShop(CustomerBuilder customerBuilder, OutputHandler outputHandler,
            Database database)
        {
            products = database.GetProducts();
            customers = database.GetCustomers();
            this.customerBuilder = customerBuilder;
            this.outputHandler = outputHandler;
            context = new MenuContext(this, database);
            this.navigation = navigation = new Navigation(context, this);
            currentChoice = 1;
            currentCustomer = null;

        }

        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");

            while (running)
            {
                context.DisplayInfo();
                context.DisplayMenu();
                navigation.DisplayNavigation();
                string Choice = Console.ReadLine().ToLower();
                navigation.LoopThroughCommands(Choice, currentChoice);
                ShowCustomerLoggedIn();
            }
        }
        
        private void ShowCustomerLoggedIn()
        {
            if (currentCustomer != null)
            {
                Console.WriteLine("Current user: " + currentCustomer.Username);
            }
            else
            {
                Console.WriteLine("Nobody logged in.");
            }
        }
    }
}