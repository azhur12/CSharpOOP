using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

public class HDD : Accumulator, ICloneable
{
    public HDD(string name, int workingSpeed, int capacity, double powerConsumption)
        : base(name, workingSpeed, capacity, powerConsumption)
    { }

    public object Clone()
    {
        return new HDD(Name, WorkingSpeed, Capacity, PowerConsumption);
    }
}