using System;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class Ship
{
    protected Ship(Engine engine, Hull hull, int mass)
    {
        Engine = engine;
        Hull = hull;
        Mass = mass;
    }

    public int Mass { get; private set; }

    public Deflector Deflector { get; set; } = new EmptyDeflector();

    public JumpingEngine JumpingEngine { get; protected set; } = new EmptyJumpingEngine();

    public bool IsAntiNitrineEmitter { get; protected set; }
    public Engine Engine { get; protected set; }
    private Hull Hull { get; set; }

    public DamageResult TakeDamage(int damage)
    {
        if (Deflector.IsDeflectorShield)
        {
            Deflector.RefreshDeflectorShield(damage);
            return DamageResult.Withstanding;
        }
        else
        {
            DamageResult result = Hull.TakeDamageHull(damage);
            return result;
        }
    }

    public DamageResult GetAntiMatterFlash()
    {
        if (Deflector.IsPhotonicDeflectors)
        {
            Deflector.RefreshPhotonicDeflectors();
            return DamageResult.Withstanding;
        }
        else
        {
            return DamageResult.CrewDeath;
        }
    }

    public int Go(int distance)
    {
        return CalculatingTime(distance, Engine);
    }

    public int Jump(int distance)
    {
        if (JumpingEngine.GetType().Name == "EmptyJumpingEngine")
        {
            Console.WriteLine("Ship doesn't have Jumping Engine");
            return -1;
        }

        return CalculatingTime(distance, JumpingEngine);
    }

    public void FillUpTheTank(int liters)
    {
        Engine.Refuel(liters);
    }

    public void FillUpTheJumpingTank(int liters)
    {
        JumpingEngine.Refuel(liters);
    }

    private int CalculatingTime(int distance, Engine engine) // Check if Engine has enough fuel,

                                                                       // and if it has, start it
    {
        int time = 0;
        double potentialDistance = ((double)Mass / 100) * engine.Power(time);
        while (potentialDistance < distance)
        {
            time++;
            if (!engine.IsEnoughOil(time))
            {
                Console.WriteLine("Doesn't have enough oil");
                return -1;
            }

            potentialDistance = ((double)Mass / 100) * engine.Power(time);
        }

        Console.WriteLine("distance covered: " + potentialDistance);

        engine.Start(time);

        return engine.Consumption(time);
    }
}