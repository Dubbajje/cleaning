namespace WebShopCleanCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebShop webShop = new WebShop(new OutputHandler(), new Database());
            webShop.Run();
        }
        
    }
}