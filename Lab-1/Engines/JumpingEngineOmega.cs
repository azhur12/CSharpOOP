using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
    {
        Power = x => 100 * (int)(x * Math.Log(x));
        TankCapacity = 300;
        Consumption = x => (int)(x * Math.Log(x));
    }
}