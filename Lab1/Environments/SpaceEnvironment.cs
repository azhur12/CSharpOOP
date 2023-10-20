using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class SpaceEnvironment
{
    protected SpaceEnvironment(int distance)
    {
        Distance = distance;
    }

    public int Distance { get; protected set; }

    public abstract int Journey(Ship ship);

    public abstract DamageResult AttackToShip(Ship ship);
}