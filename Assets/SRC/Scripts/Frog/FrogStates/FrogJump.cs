using UnityEngine;

public class FrogJump : UnitState
{
    [SerializeField] private Frog _frog;
    private Rigidbody2D _rb;

    [Header("Jump Parametres")]
    [SerializeField] private float _jumpForceUp;
    [SerializeField] private float _jumpForceSide;


    [Header("Check Ground Properties")]
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    
    private bool _onGrounded;
    [SerializeField] private float _checkRadius = 0.5f;
    private float _coolDownToJump = 0.2f;
    private float _timeToJump;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(float _sideForce)
    {
        if(_frog._currentState == GetComponent<FrogIdle>())
        {
            _frog._currentState = GetComponent<FrogJump>();

            _frog.Moved?.Invoke();

            if (_sideForce < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            _rb.linearVelocity = new Vector2(_sideForce, _jumpForceUp);
            _timeToJump = 0;
        }
    }

    private void checkGround()
    {
        _timeToJump += Time.deltaTime;
        _onGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);

        if (_onGrounded && _timeToJump >= _coolDownToJump)
        {
            _frog.SetState(GetComponent<FrogIdle>());
            _frog.Idled?.Invoke();
        }
    }

    public override void Action(Unit unit)
    {
        checkGround();
    }

    #region forAndroid
    public void JumpRight()
    {
        Jump(_jumpForceSide);
    }

    public void JumpLeft()
    {
        Jump(-_jumpForceSide);
    }

    #endregion
}
