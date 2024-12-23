using UnityEngine;

public class ChaseState : UnitState
{
    [SerializeField] private UnitState[] _transitionStates;

    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseSpeed;

    private bool _changeState = false;

    private void Start()
    {
        _target = Frog.instance.transform;
    }
    public override void Action(Unit enemy)
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _chaseSpeed * Time.deltaTime);

        if(_changeState)
        {
            enemy.SetState(_transitionStates[Random.Range(0, _transitionStates.Length)]);
            _changeState = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == _target.gameObject)
        {
            _changeState = true;
        }
    }
}
