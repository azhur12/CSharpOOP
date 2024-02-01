using Bankomat.Entities;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class ShowBalanceScenario : AbstractAccountScenario
{
    public ShowBalanceScenario(Account account)
        : base(account)
    {
    }

    public override void Run()
    {
        AnsiConsole.Clear();
        AnsiConsole.WriteLine("Your balance");
        AnsiConsole.WriteLine(Account.ShowBalance() + " ");

        AnsiConsole.WriteLine("Press K to Main Menu");
        string? ok;
        do
        {
            ok = Console.ReadLine();
            if (ok == "K") new MainMenuScenario(Account).Run();
        }
        while (ok != "K");
    }
}