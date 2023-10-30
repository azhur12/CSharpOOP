using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class VideoCardBuilder
{
    public VideoCardBuilder()
    { }

    public string Name { get; set; } = "No Name";
    public int Height { get; set; }
    public int Width { get; set; }
    public int VideoMemorySize { get; set; }
    public string PciExpressVersion { get; set; } = "No PCI-E Version";
    public double ChipFrequency { get; set; }
    public int PowerConsumptionWatts { get; set; }

    public VideoCardBuilder BuildName(string name)
    {
        Name = name;
        return this;
    }

    public VideoCardBuilder BuildHeightWidth(int height, int width)
    {
        Width = width;
        Height = height;
        return this;
    }

    public VideoCardBuilder BuildVideoMemorySize(int videoMemorySize)
    {
        VideoMemorySize = videoMemorySize;
        return this;
    }

    public VideoCardBuilder BuildPciExpressVersion(string pciExpressVersion)
    {
        PciExpressVersion = pciExpressVersion;
        return this;
    }

    public VideoCardBuilder BuildChipFrequency(double chipFrequency)
    {
        ChipFrequency = chipFrequency;
        return this;
    }

    public VideoCardBuilder BuildPowerConsumption(int powerConsumptionWatts)
    {
        PowerConsumptionWatts = powerConsumptionWatts;
        return this;
    }

    public VideoCard Build()
    {
        return new VideoCard(Name, Height, Width, VideoMemorySize, PciExpressVersion, ChipFrequency, PowerConsumptionWatts);
    }
}
