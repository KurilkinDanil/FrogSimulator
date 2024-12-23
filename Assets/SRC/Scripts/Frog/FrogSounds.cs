using UnityEngine;

public class FrogSounds : MonoBehaviour
{
    Frog _frog;
    AudioSource _audioSource;

    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _attackClip;

    private void Start()
    {
        _frog = GetComponent<Frog>();

        _frog.Moved += Jump;
        _frog.Attacked += Attack;

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        _frog.Moved -= Jump;
        _frog.Attacked -= Attack;
    }

    private void Jump()
    {
        _audioSource.clip = _jumpClip;
        _audioSource.Play();
    }

    private void Attack()
    {
        _audioSource.clip = _attackClip;
        _audioSource.Play();
    }
}
