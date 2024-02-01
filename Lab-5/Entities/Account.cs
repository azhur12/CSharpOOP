using Bankomat.Exceptions;
using Bankomat.Services;

namespace Bankomat.Entities;

public class Account
{
    public Account(string name, IDataService dataService, string pin)
    {
        Name = name;
        DataService = dataService;
        Pin = pin;
    }

    public string Name { get; init; }
    public IDataService DataService { get; set; }
    private string Pin { get; set; }

    public void Withdraw(int amount, string pin)
    {
        if (pin is null) throw new PinIsNullException();
        if (!Equals(pin, DataService.GetPin(Name))) throw new WrongPinCodeException();
        if (amount < 0) throw new InvalidArgumentException("Amount of money is below zero");
        if (amount <= DataService.GetBalance(Name))
        {
            int oldBalance = DataService.GetBalance(Name);
            DataService.Withdrawing(Name, oldBalance - amount);
            DataService.RecordAction(Name, oldBalance, oldBalance - amount, "Withdraw");
        }
        else
        {
            throw new InsofficientFundsException();
        }
    }

    public void Refill(int amount)
    {
        if (amount < 0) throw new InvalidArgumentException("Amount of money is below zero");
        int oldBalance = DataService.GetBalance(Name);
        DataService.Refill(Name, oldBalance + amount);
        DataService.RecordAction(Name, oldBalance, oldBalance + amount, "Account refill");
    }

    public int ShowBalance()
    {
        return DataService.GetBalance(Name);
    }

    public string ShowHistory()
    {
        return DataService.ShowHistory(Name);
    }
}