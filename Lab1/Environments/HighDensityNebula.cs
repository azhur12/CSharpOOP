using System.Security.Cryptography;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class HighDensityNebula : SpaceEnvironment
{
    public HighDensityNebula(int distance)
        : base(distance) { }
    public static DamageResult AntiMatterFlash(Ship ship)
    {
        int countOfFlashes = RandomNumberGenerator.GetInt32(0, 3);

        for (int i = 0; i < countOfFlashes; i++)
        {
            DamageResult result = new AntiMatterFlash().Attack(ship);
            if (result == DamageResult.CrewDeath)
            {
                return DamageResult.CrewDeath;
            }
        }

        return DamageResult.Withstanding;
    }

    public override int Journey(Ship ship)
    {
        if (ship is not null)
        {
            if (ship.JumpingEngine.GetType().Name == "EmptyJumpingEngine")
            {
                return -1;
            }

            return ship.Jump(Distance);
        }
        else
        {
            throw new EnvironmentException("Ship is null");
        }
    }

    public override DamageResult AttackToShip(Ship ship)
    {
        return AntiMatterFlash(ship);
    }
}