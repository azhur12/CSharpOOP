namespace Bankomat.Services;

public interface IViewingService
{
    void ShowBalance(string name);
    void ShowHistory(string name);
}