using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WifiAdapter : ICloneable
{
    public WifiAdapter(string name, string wifiStandardVersion, bool hasBluetoothModule, string pciExpressVersion, double powerConsumptionWatts)
    {
        Name = name;
        WifiStandardVersion = wifiStandardVersion;
        HasBluetoothModule = hasBluetoothModule;
        PciExpressVersion = pciExpressVersion;
        PowerConsumptionWatts = powerConsumptionWatts;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; set; }

    [RegularExpression("^(802\\.11[a,b,g,n,ac,ax])$", ErrorMessage = "Invalid Wi-Fi standard version")]
    public string WifiStandardVersion { get; set; }

    public bool HasBluetoothModule { get; set; }

    [RegularExpression("^(PCI-E [0-9]\\.[0-9])$", ErrorMessage = "Invalid PCI Express version")]
    public string PciExpressVersion { get; set; }

    [Range(1, int.MaxValue)]
    public double PowerConsumptionWatts { get; set; }

    public object Clone()
    {
        return new WifiAdapter(Name, WifiStandardVersion, HasBluetoothModule, PciExpressVersion, PowerConsumptionWatts);
    }
}
