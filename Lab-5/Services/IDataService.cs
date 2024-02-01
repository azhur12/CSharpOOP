namespace Bankomat.Services;

public interface IDataService
{
    int CreateAccount(string name, string pin);
    int Withdrawing(string name, int amount);
    int Refill(string name, int amount);
    int GetBalance(string name);
    string GetPin(string name);
    void RecordAction(string name, int oldBalance, int newBalance, string comment);
    string ShowHistory(string name);
    string[] FindUser(string name);
}