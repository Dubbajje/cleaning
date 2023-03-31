namespace WebShopCleanCode;

public class Sorting
{
    
    private Database db;

    public Sorting(Database db)
    {
        this.db = db;
        
    }

    public void quickSort(string variable, bool ascending)
    {
        /*List<Product> products = db.GetProducts();
        QuickSortArray(products, 0, products.Count);*/

    }

    public static void PrintArray(Product[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    public static int Partition(Product[] arr, int left, int right)
    {
        Product pivot = arr[right];
        int i = left - 1;

        /*for (int j = left; j < right; j++)
        {
            if (arr[j].Name <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, right);*/

        return i + 1;
    }
    public static void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
    public static void QuickSortArray(Product[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSortArray(arr, left, pivot - 1);
            QuickSortArray(arr, pivot + 1, right);
        }
        
    }
}