using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class JourneySimulation
{
    public static bool SimulateJourney(Ship ship, SpaceEnvironment environment, bool isAttacked)
    {
        if (isAttacked)
        {
            if (environment is not null)
            {
                DamageResult damageResult = environment.AttackToShip(ship);
                if (damageResult != DamageResult.Withstanding)
                {
                    return false;
                }
            }
            else
            {
                throw new EnvironmentException("Environment is Null");
            }
        }

        if (environment is not null)
        {
            int consumedOil = environment.Journey(ship);
            JourneyResult journeyResult = consumedOil == -1 ? JourneyResult.Failure : JourneyResult.Successful;
            return journeyResult == JourneyResult.Successful;
        }
        else
        {
            throw new EnvironmentException("Environment is null");
        }
    }

    public static void FillTheTanks(Ship ship)
    {
        if (ship is not null)
        {
            ship.FillUpTheTank(int.MaxValue);
            ship.FillUpTheJumpingTank(int.MaxValue);
        }
    }

    public static Ship CalculateOptimalShip(Ship[] shipList, SpaceEnvironment environment, bool attackFromEnvironment)
    {
        int minConsumedOil = int.MaxValue;
        Ship optimalShip = new EmptyShip();
        if (shipList == null) throw new ShipException();
        foreach (Ship ship in shipList)
        {
            if (attackFromEnvironment)
            {
                if (environment == null) throw new EnvironmentException();
                DamageResult damageResult = environment.AttackToShip(ship);
                if (damageResult != DamageResult.Withstanding)
                {
                    continue;
                }
            }

            if (environment is not null)
            {
                int consumedOil = environment.Journey(ship);
                if (consumedOil != -1 && consumedOil < minConsumedOil)
                {
                    minConsumedOil = consumedOil;
                    optimalShip = ship;
                }
            }
            else
            {
                throw new ShipException();
            }

            // Изменил for на foreach, от одного вложенного if сложно избавиться, тк анализатор просит проверять на null
        }

        return optimalShip;
    }
}
