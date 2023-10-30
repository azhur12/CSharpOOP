using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RAM : ICloneable
{
    public RAM(
        string name,
        int capacityGB,
        IEnumerable<string> supportedJedecFrequencies,
        IEnumerable<string> xmpProfiles,
        string formFactor,
        string ddrVersion,
        double powerConsumption)
    {
        Name = name;
        CapacityGB = capacityGB;
        SupportedJedecFrequencies = supportedJedecFrequencies;
        XMPProfiles = xmpProfiles;
        FormFactor = formFactor;
        DDRVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; set; }

    [Range(1, 65536)]
    public int CapacityGB { get; set; }

    public IEnumerable<string> SupportedJedecFrequencies { get; } // Список поддерживаемых частот JEDEC (не валидируется)

    public IEnumerable<string> XMPProfiles { get; } // Список профилей XMP (не валидируется)

    [RegularExpression("^(DIMM|SODIMM)$", ErrorMessage = "Invalid form factor")]
    public string FormFactor { get; set; }

    [RegularExpression("^(DDR[1-5])$", ErrorMessage = "Invalid DDR version")]
    public string DDRVersion { get; set; }

    [Range(1, int.MaxValue)]
    public double PowerConsumption { get; set; }

    public object Clone()
    {
        return new RAM(Name, CapacityGB, SupportedJedecFrequencies, XMPProfiles, FormFactor, DDRVersion, PowerConsumption);
    }
}
