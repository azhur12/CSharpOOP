using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class Engine
{
    public int TankCapacity { get; protected init; } // liters
    public Func<int, int> Power { get; protected init; } = x => 0; // power/LightHour
    public Func<int, int> Consumption { get; protected init; } = x => 0;
    private int CurrentOilLevel { get; set; }

    public int Refuel(int liters)
    {
        if (CurrentOilLevel + liters > TankCapacity)
        {
            int extraOil = CurrentOilLevel + liters - TankCapacity;
            CurrentOilLevel = TankCapacity;
            return extraOil;
        }
        else
        {
            CurrentOilLevel += liters;
            return 0;
        }
    }

    public bool IsEnoughOil(int time)
    {
        return Consumption(time) <= CurrentOilLevel;
    }

    public int Start(int time) // return potential distance covered
    {
        if ((CurrentOilLevel - Consumption(time)) < 0)
        {
            return -1;
        }

        CurrentOilLevel -= Consumption(time);
        return Consumption(time);
    }
}