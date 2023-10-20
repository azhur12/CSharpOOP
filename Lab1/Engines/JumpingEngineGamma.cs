namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma()
    {
        Power = x => 100 * x * x;
        TankCapacity = 500;
        Consumption = x => x * x;
    }
}