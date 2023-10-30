using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : ICloneable
{
    public ComputerCase(int maxVideoCardLength, int maxVideoCardWidth, IEnumerable<string> supportedMotherboardFormFactors, double width, double height)
    {
        MaxVideoCardLength = maxVideoCardLength;
        MaxVideoCardWidth = maxVideoCardWidth;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Width = width;
        Height = height;
        ComponentValidator.ValidateObject(this);
    }

    [Range(1, int.MaxValue)]
    public int MaxVideoCardLength { get; set; }

    [Range(1, int.MaxValue)]
    public int MaxVideoCardWidth { get; set; }

    public IEnumerable<string> SupportedMotherboardFormFactors { get; set; }

    [Range(1, double.MaxValue)]
    public double Width { get; set; }

    [Range(1, double.MaxValue)]
    public double Height { get; set; }

    public object Clone()
    {
        return new ComputerCase(MaxVideoCardLength, MaxVideoCardWidth, SupportedMotherboardFormFactors, Width, Height);
    }
}
