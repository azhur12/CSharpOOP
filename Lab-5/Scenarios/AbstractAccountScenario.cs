using Bankomat.Entities;

namespace Bankomat.Scenarios;

public abstract class AbstractAccountScenario : IScenario
{
    protected AbstractAccountScenario(Account account)
    {
        Account = account;
    }

    protected Account Account { get; set; }

    public abstract void Run();
}