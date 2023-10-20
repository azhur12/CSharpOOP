using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NitrinNebula : SpaceEnvironment
{
    public NitrinNebula(int distance)
        : base(distance) { }
    public static DamageResult WhaleAttack(Ship ship)
    {
        var spaceWhale = new SpaceWhale();
        if (ship is not null)
        {
            if (ship.IsAntiNitrineEmitter)
            {
                return DamageResult.Withstanding;
            }
            else
            {
                return spaceWhale.Attack(ship);
            }
        }
        else
        {
            throw new EnvironmentException("Ship is null");
        }
    }

    public override int Journey(Ship ship)
    {
        if (ship is not null)
        {
            if (ship.Engine.GetType().Name != "EngineClassE")
            {
                Console.WriteLine("Ship doesn't have Engine Class E");
                return -1;
            }

            return ship.Go(Distance);
        }
        else
        {
            throw new EnvironmentException("Ship is null");
        }
    }

    public override DamageResult AttackToShip(Ship ship)
    {
        return WhaleAttack(ship);
    }
}