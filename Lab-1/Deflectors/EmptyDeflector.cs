namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class EmptyDeflector : Deflector
{
    public EmptyDeflector()
        : base(false, false)
    {
        Shield = 0;
    }
}