namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls;

public abstract class Hull
{
    protected Hull(int armor)
    {
        Armor = armor;
    }

    private int Armor { get; set; }

    public DamageResult TakeDamageHull(int damage)
    {
        Armor -= damage;
        if (Armor <= 0)
        {
            return DamageResult.Destruction;
        }

        return DamageResult.Withstanding;
    }
}