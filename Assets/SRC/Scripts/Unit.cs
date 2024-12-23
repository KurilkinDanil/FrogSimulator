using UnityEditor.U2D;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public UnitState _currentState;

    public void SetState(UnitState state)
    {
        _currentState = state;
    }

    public virtual void Update()
    {
        _currentState.Action(this);
    }
}
