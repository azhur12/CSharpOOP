using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class MotherBoardBuilder
{
    public MotherBoardBuilder()
    { }

    public string CpuSocket { get; set; } = "No Socket";
    public int PciExpressLanes { get; set; }
    public int SataPorts { get; set; }
    public string Chipset { get; set; } = "No chipset";
    public string DdrStandard { get; set; } = "No DDR Standart";
    public int RamSlots { get; set; }
    public string FormFactor { get; set; } = "No FormFactor";
    public BIOS? Bios { get; set; }

    public MotherBoardBuilder BuildCpuSocket(string cpuSocket)
    {
        CpuSocket = cpuSocket;
        return this;
    }

    public MotherBoardBuilder BuildPciExpressLanes(int count)
    {
        PciExpressLanes = count;
        return this;
    }

    public MotherBoardBuilder BuildSataPorts(int count)
    {
        SataPorts = count;
        return this;
    }

    public MotherBoardBuilder BuildChipset(string chipset)
    {
        Chipset = chipset;
        return this;
    }

    public MotherBoardBuilder BuildDdrStandart(string standart)
    {
        DdrStandard = standart;
        return this;
    }

    public MotherBoardBuilder BuildRamSlots(int count)
    {
        RamSlots = count;
        return this;
    }

    public MotherBoardBuilder BuildFormFactor(string formFactor)
    {
        FormFactor = formFactor;
        return this;
    }

    public MotherBoardBuilder BuildBios(BIOS bios)
    {
        Bios = bios;
        return this;
    }

    public Motherboard Build(string name)
    {
        if (Bios is null)
        {
            throw new MyNullException("Bios is null");
        }

        return new Motherboard(
            name,
            CpuSocket,
            PciExpressLanes,
            SataPorts,
            Chipset,
            DdrStandard,
            RamSlots,
            FormFactor,
            Bios);
    }
}