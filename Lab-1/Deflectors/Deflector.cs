namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class Deflector
{
    protected Deflector(bool isPhotonicDeflectors, bool isDeflectorShield)
    {
        IsDeflectorShield = isDeflectorShield;
        IsPhotonicDeflectors = isPhotonicDeflectors;
        if (isPhotonicDeflectors)
        {
            PhotonicCapacity = 3;
        }
    }

    public bool IsDeflectorShield { get; private set; }
    public bool IsPhotonicDeflectors { get; private set; }
    protected int Shield { get; set; }
    private int PhotonicCapacity { get; set; }

    public void RefreshPhotonicDeflectors()
    {
        PhotonicCapacity--;
        if (PhotonicCapacity <= 0)
        {
            IsPhotonicDeflectors = false;
        }
    }

    public void RefreshDeflectorShield(int damage)
    {
        Shield -= damage;
        if (Shield <= 0)
        {
            IsDeflectorShield = false;
        }
    }
}