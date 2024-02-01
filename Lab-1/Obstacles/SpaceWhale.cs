using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhale : Obstacle
{
    public SpaceWhale() { }
    public override DamageResult Attack(Ship ship)
    {
        if (ship is not null)
        {
            if (ship.Deflector.GetType().Name == "DeflectorClassOne")
            {
                ship.TakeDamage(100); // Дефлекторы первого уровня не защищают от Кита по тестКейсу
            }

            return ship.TakeDamage(1000); // Наносим критический урон кораблю
        }
        else
        {
            throw new ObstacleException("Ship is null");
        }
    }
}