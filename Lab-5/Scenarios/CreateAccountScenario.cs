using Bankomat.Services;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class CreateAccountScenario : AbstractScenario
{
    public CreateAccountScenario(IDataService dataService)
        : base(dataService)
    {
    }

    public void Run()
    {
        AnsiConsole.Clear();
        string? name;
        do
        {
            AnsiConsole.WriteLine("Write name for your account (8 digits)");
            name = Console.ReadLine();
            if (name is null) AnsiConsole.WriteLine("Try again");
        }
        while (name is null);

        string? pin;
        do
        {
            AnsiConsole.WriteLine("Write PIN for your account (4 digits)");
            pin = Console.ReadLine();
            if (pin is null) AnsiConsole.WriteLine("Try again");
        }
        while (pin is null);

        DataService.CreateAccount(name, pin);

        AnsiConsole.WriteLine("Press K to Login Menu");
        Console.ReadLine();

        AnsiConsole.Clear();
        new LoginScenario(DataService).Run();
    }
}