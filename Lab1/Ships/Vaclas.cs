using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Vaclas : Ship
{
    private const int MassCoefficient = 85;
    public Vaclas()
        : base(new EngineClassE(), new HullClassTwo(), MassCoefficient)
    {
        JumpingEngine = new JumpingEngineGamma();
        Deflector = new DeflectorClassOne(false);
    }
}