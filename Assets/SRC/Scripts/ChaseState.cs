using UnityEngine;

public class ChaseState : UnitState
{
    [SerializeField] private UnitState[] _transitionStates;

    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseSpeed;
    public override void Action(Unit enemy)
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _chaseSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _target.position) < 0.1f)
        {
            enemy.SetState(_transitionStates[Random.Range(0, _transitionStates.Length)]);
        }
    }
}
