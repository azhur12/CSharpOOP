using System;
using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : ICloneable
{
    public Motherboard(
        string name,
        string cpuSocket,
        int pciExpressLanes,
        int sataPorts,
        string chipset,
        string ddrStandard,
        int ramSlots,
        string formFactor,
        BIOS bios)
    {
        Name = name;
        CpuSocket = cpuSocket;
        PciExpressLanes = pciExpressLanes;
        SataPorts = sataPorts;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
        ComponentValidator.ValidateObject(this);
    }

    [Required]
    public string Name { get; }

    [RegularExpression("^(LGA\\d{3,4}|Socket [A-Z0-9]+)$", ErrorMessage = "Invalid CPU socket")]
    public string CpuSocket { get; set; }

    [Range(0, int.MaxValue)]
    public int PciExpressLanes { get; set; }

    [Range(0, int.MaxValue)]
    public int SataPorts { get; set; }

    [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Invalid chipset")]
    public string Chipset { get; set; }

    [RegularExpression("^(DDR[1-5])$", ErrorMessage = "Invalid DDR standard")]
    public string DdrStandard { get; set; }

    [Range(1, 8)]
    public int RamSlots { get; set; }

    [RegularExpression("^(ATX|MicroATX|Mini-ITX)$", ErrorMessage = "Invalid form factor")]
    public string FormFactor { get; set; }

    public BIOS Bios { get; set; }
    public object Clone()
    {
        return new Motherboard(Name, CpuSocket, PciExpressLanes, SataPorts, Chipset, DdrStandard, RamSlots, FormFactor, (BIOS)Bios.Clone());
    }
}
