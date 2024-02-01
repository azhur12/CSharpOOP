using Bankomat.Services;

namespace Bankomat.Entities;

public class AuthentificationService : IAuthenticationService
{
    public AuthentificationService(IDataService dataService)
    {
        DataService = dataService;
    }

    private IDataService DataService { get; set; }
    public IAuthenticationResults FindUser(string name, string pin)
    {
        string[] row = DataService.FindUser(name);
        if (row == Array.Empty<string>())
        {
            return IAuthenticationResults.Fail;
        }

        if (row[2] == pin)
        {
            return IAuthenticationResults.Success;
        }
        else
        {
            return IAuthenticationResults.Fail;
        }
    }
}