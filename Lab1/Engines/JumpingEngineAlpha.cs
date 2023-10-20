namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
    {
        Power = x => 100 * x;
        TankCapacity = 200;
        Consumption = x => x;
    }
}