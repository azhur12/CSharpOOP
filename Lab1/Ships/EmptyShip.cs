using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class EmptyShip : Ship
{
    private const int MassCoefficient = 0;
    public EmptyShip()
        : base(new EngineClassC(), new HullClassOne(), MassCoefficient)
    { }
}