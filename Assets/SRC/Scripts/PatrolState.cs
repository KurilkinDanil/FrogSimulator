using UnityEngine;

public class PatrolState : UnitState
{
    [SerializeField] private float _moveSpeed;

    [Space]
    [SerializeField] private UnitState[] _transitionStates;

    [Space]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    private Vector2 patrolPoint;

    private void Start()
    {
        GetRandomPoint();
    }

    public override void Action(Unit unit)
    {
        Patrolling(unit);
    }
    private void Patrolling(Unit unit)
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoint) < 0.1f)
        {
            GetRandomPoint();

            if (_transitionStates.Length > 0)
            {
                unit.SetState(_transitionStates[Random.Range(0, _transitionStates.Length)]);
            }
        }
    }

   private void GetRandomPoint()
    {
        patrolPoint =  new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
    }
}
