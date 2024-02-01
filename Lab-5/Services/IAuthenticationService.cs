namespace Bankomat.Services;

public interface IAuthenticationService
{
    IAuthenticationResults FindUser(string name, string pin);
}