using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Shuttle : Ship
{
    private const int MassCoefficient = 95;
    public Shuttle()
        : base(new EngineClassC(), new HullClassOne(), MassCoefficient)
    {
    }
}