using Bankomat.Entities;
using Bankomat.Exceptions;
using Bankomat.Services;
using Spectre.Console;

namespace Bankomat.Scenarios;

public class LoginScenario : IScenario
{
    public LoginScenario(IDataService dataService)
    {
        DataService = dataService;
        AuthenticationService = new AuthentificationService(dataService);
    }

    private IDataService DataService { get; set; }
    private IAuthenticationService AuthenticationService { get; set; }
    public void Run()
    {
        AnsiConsole.Clear();
        var table = new Table();
        table.AddColumn("№");
        table.AddColumn("Choose mode");

        table.AddRow("1", "User");
        table.AddRow("2", "Admin");
        table.AddRow("3", "Create Account");
        AnsiConsole.Write(table);

        AnsiConsole.WriteLine("Choose number of mode");

        string? mode;
        do
        {
            mode = Console.ReadLine();
            if (mode is null) AnsiConsole.WriteLine("Try Again");
        }
        while (mode is null);

        if (mode == "1")
        {
            AnsiConsole.Clear();
            string? name;
            do
            {
                AnsiConsole.WriteLine("Enter your account name (8 digits)");
                name = Console.ReadLine();
                if (name is null) AnsiConsole.WriteLine("Try again");
            }
            while (name is null);

            string? pin;
            do
            {
                AnsiConsole.WriteLine("Enter PIN (4 digits)");
                pin = Console.ReadLine();
                if (pin is null) AnsiConsole.WriteLine("Try again");
            }
            while (pin is null);

            if (AuthenticationService.FindUser(name, pin) == IAuthenticationResults.Success)
            {
                string[] user = DataService.FindUser(name);
                new MainMenuScenario(new Account(user[1], DataService, user[2])).Run();
            }
            else
            {
                AnsiConsole.WriteLine("There is no such Account");
                Console.Read();
                new LoginScenario(DataService).Run();
            }
        }
        else if (mode == "2")
        {
            string? systemPass;
            do
            {
                AnsiConsole.WriteLine("Enter account name (8 digits)");
                systemPass = Console.ReadLine();
                if (systemPass is null) AnsiConsole.WriteLine("Try again");
            }
            while (systemPass is null);

            if (string.Equals(systemPass, "12345", StringComparison.Ordinal)) throw new InvalidPasswordException();

            AnsiConsole.Clear();
            string? name;
            do
            {
                AnsiConsole.WriteLine("Enter account name (8 digits)");
                name = Console.ReadLine();
                if (name is null) AnsiConsole.WriteLine("Try again");
            }
            while (name is null);

            if (AuthenticationService.FindUser(name, DataService.GetPin(name)) == IAuthenticationResults.Success)
            {
                string[] user = DataService.FindUser(name);
                new MainMenuScenario(new Account(user[1], DataService, user[2])).Run();
            }
            else
            {
                AnsiConsole.WriteLine("There is no such Account");
                Console.Read();
                new LoginScenario(DataService).Run();
            }
        }

        if (mode == "3")
        {
            AnsiConsole.Clear();
            new CreateAccountScenario(DataService).Run();
        }
    }
}