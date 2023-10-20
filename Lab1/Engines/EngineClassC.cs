namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassC : Engine
{
    public EngineClassC()
    {
        Power = x => 5 * x;
        TankCapacity = 600;
        Consumption = x => x;
    }
}