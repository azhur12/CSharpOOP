using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorite : Obstacle
{
    private const int Damage = 30;
    public Meteorite() { }

    public override DamageResult Attack(Ship ship)
    {
        if (ship is not null)
        {
            int realDamage = (int)(Damage * ((double)ship.Mass / 100));
            return ship.TakeDamage(realDamage);
        }
        else
        {
            throw new ObstacleException("Ship is null");
        }
    }
}