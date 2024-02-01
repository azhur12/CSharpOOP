using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : ICloneable
{
    public PowerSupply(string name, int volts)
    {
        Name = name;
        PeakLoad = volts;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; init; }

    [Range(1, int.MaxValue)]
    public int PeakLoad { get; private init; }

    public object Clone()
    {
        return new PowerSupply(Name, PeakLoad);
    }
}