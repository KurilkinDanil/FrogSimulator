using UnityEngine;

public interface IBuffable
{
    public void ApplyBuff(IBuff buff);
    public void RemoveBuff(IBuff buff);
}
