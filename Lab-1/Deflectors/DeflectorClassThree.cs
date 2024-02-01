namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassThree : Deflector
{
    public DeflectorClassThree(bool isPhotonicDeflectors)
        : base(isPhotonicDeflectors, true)
    {
        Shield = 400;
    }
}