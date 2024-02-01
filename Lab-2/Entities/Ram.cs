using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : ICloneable
{
    public Ram(
        string name,
        int capacityGb,
        IEnumerable<string> supportedJedecFrequencies,
        IEnumerable<string> xmpProfiles,
        string formFactor,
        string ddrVersion,
        double powerConsumption)
    {
        Name = name;
        CapacityGb = capacityGb;
        SupportedJedecFrequencies = supportedJedecFrequencies;
        XmpProfiles = xmpProfiles;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; set; }

    [Range(1, 65536)]
    public int CapacityGb { get; set; }

    public IEnumerable<string> SupportedJedecFrequencies { get; } // Список поддерживаемых частот JEDEC (не валидируется)

    public IEnumerable<string> XmpProfiles { get; } // Список профилей XMP (не валидируется)

    [RegularExpression("^(DIMM|SODIMM)$", ErrorMessage = "Invalid form factor")]
    public string FormFactor { get; set; }

    [RegularExpression("^(DDR[1-5])$", ErrorMessage = "Invalid DDR version")]
    public string DdrVersion { get; set; }

    [Range(1, int.MaxValue)]
    public double PowerConsumption { get; set; }

    public object Clone()
    {
        return new Ram(Name, CapacityGb, SupportedJedecFrequencies, XmpProfiles, FormFactor, DdrVersion, PowerConsumption);
    }
}
