namespace WebShopCleanCode;

public class Sorting
{
    //I have changed Bubblesort to Mergesort


    private Database db;

    public Sorting(Database db)
    {
        this.db = db;

    }
    public void MergeSortByName( bool ascending)
    {
        
        MergeSort(db.GetProducts(), "name", ascending);
    }

    public void MergeSortByPrice(bool ascending)
    {
        MergeSort(db.GetProducts(), "price", ascending);
    }
    

    private void MergeSort(List<Product> products, string variable, bool ascending)
    {
        if (products.Count <= 1)
        {
            return;
        }

        int middle = products.Count / 2;
        List<Product> left = new List<Product>();
        List<Product> right = new List<Product>();

        for (int i = 0; i < middle; i++)
        {
            left.Add(products[i]);
        }

        for (int i = middle; i < products.Count; i++)
        {
            right.Add(products[i]);
        }

        MergeSort(left, variable, ascending);
        MergeSort(right, variable, ascending);

        Merge(left, right, products, variable, ascending);
    }

    public void Merge(List<Product> left, List<Product> right, List<Product> products, string variable, bool ascending)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int productsIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (variable.Equals("name"))
            {
                if ((ascending && left[leftIndex].Name.CompareTo(right[rightIndex].Name) <= 0) ||
                    (!ascending && left[leftIndex].Name.CompareTo(right[rightIndex].Name) >= 0))
                {
                    products[productsIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    products[productsIndex] = right[rightIndex];
                    rightIndex++;
                }
            }
            else if (variable.Equals("price"))
            {
                if ((ascending && left[leftIndex].Price <= right[rightIndex].Price) ||
                    (!ascending && left[leftIndex].Price >= right[rightIndex].Price))
                {
                    products[productsIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    products[productsIndex] = right[rightIndex];
                    rightIndex++;
                }
            }

            productsIndex++;
        }

        while (leftIndex < left.Count)
        {
            products[productsIndex] = left[leftIndex];
            leftIndex++;
            productsIndex++;
        }

        while (rightIndex < right.Count)
        {
            products[productsIndex] = right[rightIndex];
            rightIndex++;
            productsIndex++;
        }
    }
}