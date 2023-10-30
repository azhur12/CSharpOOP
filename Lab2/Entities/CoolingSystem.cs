using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CoolingSystem : ICloneable
{
    public CoolingSystem(string name, int height, int width, IEnumerable<string> supportedSockets, int maxTDP)
    {
        Name = name;
        Height = height;
        Width = width;
        SupportedSockets = supportedSockets;
        MaxTDP = maxTDP;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; init; }

    [Range(1, int.MaxValue)]
    public int Height { get; init; }

    [Range(1, int.MaxValue)]
    public int Width { get; init; }

    public IEnumerable<string> SupportedSockets { get; }

    [Range(1, int.MaxValue)]
    public int MaxTDP { get; set; } // Максимально рассеиваемая масса тепла (TDP)

    public object Clone()
    {
        return new CoolingSystem(Name, Height, Width, SupportedSockets, MaxTDP);
    }
}
