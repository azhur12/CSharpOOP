using Bankomat.Entities;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class ShowHistoryScenario : AbstractAccountScenario
{
    public ShowHistoryScenario(Account account)
        : base(account)
    {
    }

    public override void Run()
    {
        string outstr = Account.ShowHistory();
        AnsiConsole.Write(outstr);

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