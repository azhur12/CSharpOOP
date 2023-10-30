using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

public class SSD : Accumulator, ICloneable
{
    public SSD(string name, int workingSpeed, int capacity, double powerConsumption, string connection)
        : base(name, workingSpeed, capacity, powerConsumption)
    {
        Connection = connection;
    }

    public string Connection { get; init; }
    public object Clone()
    {
        return new SSD(Name, WorkingSpeed, Capacity, PowerConsumption, Connection);
    }
}