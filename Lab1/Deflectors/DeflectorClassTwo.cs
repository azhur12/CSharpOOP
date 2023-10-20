namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassTwo : Deflector
{
    public DeflectorClassTwo(bool isPhotonicDeflectors)
        : base(isPhotonicDeflectors, true)
    {
        Shield = 100;
    }
}