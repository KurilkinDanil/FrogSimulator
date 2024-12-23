using UnityEngine;

[RequireComponent (typeof(Animator))]
public class FrogAnimations : MonoBehaviour
{
    Frog _frog;
    Animator _animator;

    private void Start()
    {
        _frog = GetComponent<Frog>();

        _frog.Idled += Idle;
        _frog.Moved += Jump;
        _frog.Attacked += Attack;

        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _frog.Idled -= Idle;
        _frog.Moved -= Jump;
        _frog.Attacked -= Attack;
    }

    private void Idle()
    {
        _animator.SetTrigger("Idle");
    }

    private void Jump()
    {
        _animator.SetTrigger("Jump");
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
