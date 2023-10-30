using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CPUBuilder
{
    public CPUBuilder()
    { }
    public int ClockSpeed { get; set; } // Частота ядер в ГГц
    public int NumberOfCores { get; set; }
    public string Socket { get; set; } = "No Socket";
    public bool IntegratedGraphics { get; set; } // Наличие встроенного видеоядра
    public IList<string> SupportedMemoryFrequencies { get; } = new List<string>(); // Поддерживаемые частоты памяти
    public int TDP { get; set; } // Тепловыделение (TDP) в ваттах
    public int PowerConsumption { get; set; }

    public CPUBuilder BuildCores(int clockSpeed, int numberOfCores)
    {
        ClockSpeed = clockSpeed;
        NumberOfCores = numberOfCores;
        return this;
    }

    public CPUBuilder BuildSocket(string socket)
    {
        Socket = socket;
        return this;
    }

    public CPUBuilder BuildTDPAndPower(int tdp, int power)
    {
        TDP = tdp;
        PowerConsumption = power;
        return this;
    }

    public CPUBuilder BuildAddList(IList<string> list)
    {
        SupportedMemoryFrequencies.Clear();
        if (list != null)
        {
            foreach (string frequency in list)
            {
                SupportedMemoryFrequencies.Add(frequency);
            }
        }

        return this;
    }

    public Processor Build(string name)
    {
        return new Processor(
            name,
            ClockSpeed,
            NumberOfCores,
            Socket,
            IntegratedGraphics,
            SupportedMemoryFrequencies,
            TDP,
            PowerConsumption);
    }
}