using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

public class Sdd : Accumulator, ICloneable
{
    public Sdd(string name, int workingSpeed, int capacity, double powerConsumption, string connection)
        : base(name, workingSpeed, capacity, powerConsumption)
    {
        Connection = connection;
    }

    public string Connection { get; init; }
    public object Clone()
    {
        return new Sdd(Name, WorkingSpeed, Capacity, PowerConsumption, Connection);
    }
}