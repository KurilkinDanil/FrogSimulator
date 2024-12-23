using UnityEngine;

public class FrogIdle : UnitState
{
    public override void Action(Unit unit)
    {
        Debug.Log("Idle");
    }
}
