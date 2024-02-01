using Bankomat.Entities;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class MainMenuScenario : AbstractAccountScenario
{
    public MainMenuScenario(Account account)
        : base(account)
    {
    }

    public override void Run()
    {
        AnsiConsole.Clear();
        var table = new Table();
        table.AddColumn("№");
        table.AddColumn("Choose option");

        table.AddRow("1", "Show balance");
        table.AddRow("2", "Refill balance");
        table.AddRow("3", "WithDraw");
        table.AddRow("4", "Show history");
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine("Choose number of option");
        string? option;
        do
        {
            option = Console.ReadLine();
            if (option is null) Console.WriteLine("Try again");
        }
        while (option is null);

        int optionNumber = int.Parse(option, null);

        switch (optionNumber)
        {
            case 1:
                new ShowBalanceScenario(Account).Run();
                break;
            case 2:
                new RefillScenario(Account).Run();
                break;
            case 3:
                new WithdrawScenario(Account).Run();
                break;
            case 4:
                new ShowHistoryScenario(Account).Run();
                break;
        }
    }
}