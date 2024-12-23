using UnityEngine;

public class TakeDamageEffect : EatEffect
{
    [SerializeField] private int _damage;

    public override void Eat(FrogStats frogStats)
    {
        frogStats.ApplyDamage(_damage);
    }
}
