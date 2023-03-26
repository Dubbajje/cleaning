namespace WebShopCleanCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebShop webShop = new WebShop(new CustomerBuilder());
            webShop.Run();
        }
    }
}