using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

public class Hdd : Accumulator, ICloneable
{
    public Hdd(string name, int workingSpeed, int capacity, double powerConsumption)
        : base(name, workingSpeed, capacity, powerConsumption)
    { }

    public object Clone()
    {
        return new Hdd(Name, WorkingSpeed, Capacity, PowerConsumption);
    }
}