using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard : ICloneable
{
    public VideoCard(string name, int height, int width, int videoMemorySize, string pciExpressVersion, double chipFrequency, double powerConsumptionWatts)
    {
        Name = name;
        Height = height;
        Width = width;
        VideoMemorySize = videoMemorySize;
        PciExpressVersion = pciExpressVersion;
        ChipFrequency = chipFrequency;
        PowerConsumptionWatts = powerConsumptionWatts;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; set; }

    [Range(1, 200)]
    public int Height { get; set; }

    [Range(1, 150)]
    public int Width { get; set; }

    [Range(1, 32768)]
    public int VideoMemorySize { get; set; }

    public string PciExpressVersion { get; set; } // Нет специфических атрибутов для валидации текстового поля

    [Range(1.0, 2500.0)]
    public double ChipFrequency { get; set; }

    [Range(1, int.MaxValue)]
    public double PowerConsumptionWatts { get; set; }

    public object Clone()
    {
        return new VideoCard(Name, Height, Width, VideoMemorySize, PciExpressVersion, ChipFrequency, PowerConsumptionWatts);
    }
}
