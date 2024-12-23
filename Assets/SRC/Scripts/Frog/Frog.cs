using System;
using System.Collections.Generic;

public class Frog : Unit, IBuffable
{
    public FrogStats BaseStats { get; }
    public FrogStats CurrentStats { get; private set; }

    private readonly List<IBuff> _buffs = new();

    public Frog(FrogStats baseStats)
    {
        BaseStats = baseStats;
        CurrentStats = baseStats;
    }

    public Action Idled;
    public Action Moved;
    public Action Attacked;

    public void ApplyBuff(IBuff buff)
    {
        _buffs.Add(buff);
        ApplyBuffs();
    }

    public void RemoveBuff(IBuff buff)
    {
        _buffs.Remove(buff);
        ApplyBuffs();
    }

    private void ApplyBuffs()
    {
        CurrentStats = BaseStats;

        foreach (var buff in _buffs)
        {
            CurrentStats = buff.ApplyBuff(BaseStats);
        }
    }
}