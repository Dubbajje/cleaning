namespace WebShopCleanCode;

public class SortMenu : Menu
{
    public SortMenu()
    {
        option1 = "Sort by name, descending";
        option2 = "Sort by name, ascending";
        option3 = "Sort by price, descending";
        option4 = "Sort by price, ascending";
        info = "How would you like to sort them?";
        currentMenu = "sort menu";
        currentChoice = 1;
        amountOfOptions = 4;
    }
}