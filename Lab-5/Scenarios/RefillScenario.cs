using Bankomat.Entities;
using Bankomat.Exceptions;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class RefillScenario : AbstractAccountScenario
{
    public RefillScenario(Account account)
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

        bool ok = false;
        while (ok == false)
        {
            try
            {
                Account.Refill(int.Parse(amount, null));
                ok = true;
            }
            catch (Exception e) when (e is InvalidArgumentException)
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