using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class EngineClassE : Engine
{
    public EngineClassE()
    {
        Power = x => (int)Math.Exp(x);
        TankCapacity = 500;
        Consumption = x => 50 * x;
    }
}