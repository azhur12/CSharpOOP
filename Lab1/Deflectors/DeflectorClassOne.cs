namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassOne : Deflector
{
    public DeflectorClassOne(bool isPhotonicDeflectors)
        : base(isPhotonicDeflectors, true)
    {
        Shield = 30;
    }
}