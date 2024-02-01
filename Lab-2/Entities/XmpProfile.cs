using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile : ICloneable
{
    public XmpProfile(string timings, double voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    [RegularExpression(@"^\d+-\d+-\d+-\d+$", ErrorMessage = "Invalid timing format")]
    public string Timings { get; init; }

    [Range(1.0, double.MaxValue)]
    public double Voltage { get; init; }

    [Range(1, int.MaxValue)]
    public int Frequency { get; init; }

    public object Clone()
    {
        return new XmpProfile(Timings, Voltage, Frequency);
    }
}
