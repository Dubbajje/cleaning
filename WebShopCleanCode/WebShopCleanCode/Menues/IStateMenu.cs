namespace WebShopCleanCode;

public interface IStateMenu
{
    public void DisplayMenu();

    
    void Execute(int currentChoice);
    void DisplayInfo();

    int GetAmountOfOptions();
    void PreviousMenu();
}