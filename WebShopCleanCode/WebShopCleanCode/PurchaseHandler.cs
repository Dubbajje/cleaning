namespace WebShopCleanCode;

public class PurchaseHandler
{
    private WebShop _webShop;
    private Database _db;
    private OutputHandler _output;
    private List<Product> products;
    public PurchaseHandler(WebShop webShop, Database db, OutputHandler output)
    {
        _webShop = webShop;
        _db = db;
        products = db.GetProducts();
        _output = output;

    }
    public void Purchase()
    {
        int index = _webShop.CurrentChoice - 1;
        Product product = products[index];
        if (product.InStock())
        {
            if (_webShop.CurrentCustomer.CanAfford(product.Price))
            {
                _webShop.CurrentCustomer.Funds -= product.Price;
                product.NrInStock--;
                _webShop.CurrentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                _output.DisplayMessageWithArgument("Successfully bought ", product.Name);
            }
            else
            {
                _output.DisplayMessage("You cannot afford.");
            }
        }
        else
        {
            _output.DisplayMessage("Not in stock.");
        }
    }
    
}