using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Augur : Ship
{
    private const int MassCoefficient = 45;
    public Augur()
        : base(
            new EngineClassE(),
            new HullClassThree(),
            MassCoefficient)
    {
        JumpingEngine = new JumpingEngineAlpha();
        Deflector = new DeflectorClassThree(false);
    }
}