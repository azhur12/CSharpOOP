using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meridian : Ship
{
    private const int MassCoefficient = 85;
    public Meridian()
        : base(
            new EngineClassE(),
            new HullClassTwo(),
            MassCoefficient)
    {
        IsAntiNitrineEmitter = true;
        Deflector = new DeflectorClassTwo(false);
    }
}