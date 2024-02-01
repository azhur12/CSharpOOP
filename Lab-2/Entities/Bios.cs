using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : ICloneable
{
    public Bios(string name, string type, string version, IEnumerable<string> supportedProcessors)
    {
        Name = name;
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; init; }
    public string Type { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string Version { get; set; }

    public IEnumerable<string> SupportedProcessors { get; set; }

    public object Clone()
    {
        return new Bios(Name, Type, Version, SupportedProcessors);
    }
}
