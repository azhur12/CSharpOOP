using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntiMatterFlash : Obstacle
{
    public AntiMatterFlash() { }

    public override DamageResult Attack(Ship ship)
    {
        if (ship is not null)
        {
            return ship.GetAntiMatterFlash();
        }
        else
        {
            throw new ObstacleException("Ship is null");
        }
    }
}