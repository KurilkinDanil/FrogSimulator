using System.Runtime.InteropServices;
using UnityEngine;

public class FrogAttack : UnitState
{
    [SerializeField] private Frog _frog;
    [SerializeField] private FrogTongue _frogTongue;

    [Header("Tongue Properties")]
    [SerializeField] private Transform _linePos0;
    [SerializeField] private Transform _tongueObj;

    [SerializeField] private float _attackSpeed = 40;
    [SerializeField] private float _backAttackSpeed = 15;
    [SerializeField] private float _damage;

    private bool _moveTongue;
    private bool _attack;

    private Vector2 _mousePos;
    private Camera mainCamera => Camera.main;
    private LineRenderer _lineRenderer;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void DrawTongue()
    {
        _lineRenderer.SetPosition(0, _linePos0.position);
        _lineRenderer.SetPosition(1, _tongueObj.position);
    }

    private void TongueMove()
    {
        DrawTongue();

        if (Vector2.Distance(_tongueObj.transform.position, _mousePos) < 0.1) // когда язык лягушки доходит до позиции клика тогда движение язка выключается
        {
            StopAttack();
        }

        if (_moveTongue == false && Vector2.Distance(_tongueObj.transform.position, _linePos0.transform.position) == 0)
        {
            _attack = false;
            _frog.SetState(GetComponent<FrogIdle>());
            _frog.Idled?.Invoke();
        }

        if (_moveTongue)
        {
            _tongueObj.transform.position = Vector2.MoveTowards(_tongueObj.transform.position, _mousePos, Time.deltaTime * _attackSpeed);
        }
        else
        {
            _tongueObj.transform.position = Vector2.MoveTowards(_tongueObj.transform.position, _linePos0.position, Time.deltaTime * _backAttackSpeed); // когда движение языка выключено язык возвращается в LinePos0
        }
    }

    public void Attack()
    {
        if(_frog._currentState == GetComponent<FrogIdle>())
        {
            if (_attack == false)
            {
                _mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);

                FlipToSideAttack();

                _attack = true;
                _moveTongue = true;
                _frog.SetState(GetComponent<FrogAttack>());
                _frog.Attacked?.Invoke();
            }
        }
    }
    public void StopAttack()
    {
        _moveTongue = false;
    }

    private void FlipToSideAttack()
    {
        if (_mousePos.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public override void Action(Unit unit)
    {
        TongueMove();
    }
}
