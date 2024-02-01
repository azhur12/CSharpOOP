// See https://aka.ms/new-console-template for more information

using Bankomat.Repositories;
using Bankomat.Scenarios;

var dataSource = new PostgresRepository();
var loginMenu = new LoginScenario(dataSource);
loginMenu.Run();