using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

public abstract class Accumulator
{
    protected Accumulator(string name, int workingSpeed, int capacity, double powerConsumption)
    {
        Name = name;
        WorkingSpeed = workingSpeed;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; init; }

    [Range(1, int.MaxValue)]
    public int WorkingSpeed { get; init; }

    [Range(1, int.MaxValue)]
    public int Capacity { get; init; }

    [Range(1, int.MaxValue)]
    public double PowerConsumption { get; init; }
}
