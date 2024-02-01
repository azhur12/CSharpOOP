namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EmptyJumpingEngine : JumpingEngine
{
    public EmptyJumpingEngine()
    {
        Power = x => 0;
        TankCapacity = 1;
        Consumption = x => 0;
    }
}