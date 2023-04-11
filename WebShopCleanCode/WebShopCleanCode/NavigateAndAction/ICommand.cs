namespace WebShopCleanCode;

public interface ICommand
{
    //This is part of the Command pattern. This is the interface that all the buttons use
    // but with different implementation.
    void Execute(int currentChoice);
}