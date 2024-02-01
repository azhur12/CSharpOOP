using Bankomat.Services;

namespace Bankomat.Scenarios;

public abstract class AbstractScenario
{
    protected AbstractScenario(IDataService dataService)
    {
        DataService = dataService;
    }

    protected IDataService DataService { get; set; }
}