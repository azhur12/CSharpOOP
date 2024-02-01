using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    public abstract DamageResult Attack(Ship ship);
}