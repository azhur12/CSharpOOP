using System.Collections.Generic;
using System.Security.Cryptography;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NormalSpace : SpaceEnvironment
{
    public NormalSpace(int distance)
        : base(distance) { }
    public static DamageResult LightAttack(Ship ship)
    {
        return Attack(ship, 0, 1, 1, 3);
    }

    public static DamageResult MediumAttack(Ship ship)
    {
        return Attack(ship, 1, 3, 3, 10);
    }

    public static DamageResult HeavyAttack(Ship ship)
    {
        return Attack(ship, 3, 10, 10, 40);
    }

    public override int Journey(Ship ship)
    {
        if (ship is not null)
        {
            return ship.Go(Distance);
        }
        else
        {
            throw new ObstacleException("Ship is null");
        }
    }

    public override DamageResult AttackToShip(Ship ship)
    {
        return Attack(ship, 0, 5, 1, 40);
    }

    private static DamageResult Attack(Ship ship, int minMet, int maxMet, int minAst, int maxAst)
    {
        int countOfAsteroid = RandomNumberGenerator.GetInt32(minAst, maxAst);
        int countOfMeteorites = RandomNumberGenerator.GetInt32(minMet, maxMet);

        var obstaclesList = new List<Obstacle>();

        for (int i = 0; i < countOfMeteorites; i++)
        {
            obstaclesList.Add(new Meteorite());
        }

        for (int i = 0; i < countOfAsteroid; i++)
        {
            obstaclesList.Add(new Asteroid());
        }

        foreach (Obstacle obstacle in obstaclesList)
        {
            DamageResult result = obstacle.Attack(ship);
            if (result == DamageResult.Destruction)
            {
                return DamageResult.Destruction;
            }
        }

        return DamageResult.Withstanding;
    }
}