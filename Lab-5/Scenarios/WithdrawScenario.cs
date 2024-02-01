using Bankomat.Entities;
using Bankomat.Exceptions;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class WithdrawScenario : AbstractAccountScenario
{
    public WithdrawScenario(Account account)
        : base(account)
    {
    }

    public override void Run()
    {
        AnsiConsole.Clear();
        string? amount;
        do
        {
            AnsiConsole.WriteLine("Enter amount of money");
            amount = Console.ReadLine();
            if (amount is null) AnsiConsole.WriteLine("Try again");
        }
        while (amount is null);

        string? pin;
        do
        {
            AnsiConsole.WriteLine("Enter your pin");
            pin = Console.ReadLine();
            if (pin is null) AnsiConsole.WriteLine("Try again");
        }
        while (pin is null);

        bool ok = false;
        while (ok == false)
        {
            try
            {
                Account.Withdraw(int.Parse(amount, null), pin);
                ok = true;
            }
            catch (Exception e) when (e is InvalidArgumentException || e is WrongPinCodeException)
            {
                AnsiConsole.WriteLine(e.Message);
                AnsiConsole.WriteLine("Try again");
            }
        }

        AnsiConsole.WriteLine("Press K to Main Menu");
        string? ok1;
        do
        {
            ok1 = Console.ReadLine();
            if (ok1 == "K") new MainMenuScenario(Account).Run();
        }
        while (ok1 != "K");
    }
}