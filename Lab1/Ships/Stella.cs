using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Stella : Ship
{
    private const int MassCoefficient = 95;
    public Stella()
        : base(new EngineClassC(), new HullClassOne(), MassCoefficient)
    {
        JumpingEngine = new JumpingEngineOmega();
        Deflector = new DeflectorClassOne(false);
    }
}