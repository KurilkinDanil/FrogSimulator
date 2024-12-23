using UnityEngine;

public class FrogInput : MonoBehaviour
{
    [SerializeField] private FrogJump _frogJump;
    [SerializeField] private FrogAttack _frogAttack;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _frogJump.Jump(-5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _frogJump.Jump(5);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _frogAttack.Attack();
        }
    }
}
