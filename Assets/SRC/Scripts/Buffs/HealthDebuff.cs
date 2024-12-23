using UnityEngine;

public class HealthDebuff : IBuff
{
    private int _damage;

    public HealthDebuff(int damage)
    {
        _damage = damage;
    }

    public FrogStats ApplyBuff(FrogStats baseStats)
    {
        var newStats = baseStats;

        newStats.ApplyDamage(_damage);

        return newStats;
    }
}
