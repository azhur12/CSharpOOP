using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CpuBuilder
{
    public CpuBuilder()
    { }
    public int ClockSpeed { get; set; } // Частота ядер в ГГц
    public int NumberOfCores { get; set; }
    public string? Socket { get; set; }
    public bool IntegratedGraphics { get; set; } // Наличие встроенного видеоядра
    public IList<string>? SupportedMemoryFrequencies { get; } // Поддерживаемые частоты памяти
    public int Tdp { get; set; } // Тепловыделение (TDP) в ваттах
    public int PowerConsumption { get; set; }

    public CpuBuilder BuildCores(int clockSpeed, int numberOfCores)
    {
        ClockSpeed = clockSpeed;
        NumberOfCores = numberOfCores;
        return this;
    }

    public CpuBuilder BuildSocket(string socket)
    {
        Socket = socket;
        return this;
    }

    public CpuBuilder BuildTdpAndPower(int tdp, int power)
    {
        Tdp = tdp;
        PowerConsumption = power;
        return this;
    }

    public CpuBuilder BuildAddList(IList<string> list)
    {
        SupportedMemoryFrequencies?.Clear();
        if (list is not null)
        {
            foreach (string frequency in list)
            {
                SupportedMemoryFrequencies?.Add(frequency);
            }
        }

        return this;
    }

    public Processor Build(string name)
    {
        if (Socket is null || SupportedMemoryFrequencies is null) throw new MyNullException();
        return new Processor(
            name,
            ClockSpeed,
            NumberOfCores,
            Socket,
            IntegratedGraphics,
            SupportedMemoryFrequencies,
            Tdp,
            PowerConsumption);
    }
}