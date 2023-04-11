namespace WebShopCleanCode;

public interface IStateMenu
{
    //The interface for the State pattern
    public void DisplayMenu();
    
    void Execute(int currentChoice);
    void DisplayInfo();

    int GetAmountOfOptions();
    void PreviousMenu();
    void SetLoggedInOptions();
}