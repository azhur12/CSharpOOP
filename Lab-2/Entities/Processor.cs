using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Processor : ICloneable
{
    public Processor(
        string name,
        int clockSpeed,
        int numberOfCores,
        string socket,
        bool integratedGraphics,
        IEnumerable<string> supportedMemoryFrequencies,
        int tdp,
        double powerConsumption)
    {
        Name = name;
        ClockSpeed = clockSpeed;
        NumberOfCores = numberOfCores;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; set; }

    [Range(1, int.MaxValue)]
    public int ClockSpeed { get; set; } // Частота ядер в ГГц

    [Range(1, 128)]
    public int NumberOfCores { get; set; }

    public string Socket { get; set; }

    public bool IntegratedGraphics { get; set; }

    public IEnumerable<string> SupportedMemoryFrequencies { get; }

    [Range(1, int.MaxValue)]
    public int Tdp { get; set; } // Тепловыделение (TDP) в ваттах

    [Range(1, int.MaxValue)]
    public double PowerConsumption { get; set; }

    public object Clone()
    {
        return new Processor(Name, ClockSpeed, NumberOfCores, Socket, IntegratedGraphics, SupportedMemoryFrequencies, Tdp, PowerConsumption);
    }
}
