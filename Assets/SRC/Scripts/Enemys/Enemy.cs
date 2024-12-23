using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit, ITouchedTongue, iWasEating
{
    [SerializeField] private List<EatEffect> _eatEffect;

    [SerializeField] private AudioClip _flyGrabbleSound;

    public virtual void Eat(FrogStats frogStats)
    {
        if (_eatEffect != null)
        {
            foreach (var effect in _eatEffect)
            {
                effect.Eat(frogStats);
            }
        }
    }

    public virtual void TouchHandler(FrogTongue tongue)
    {
        Debug.Log("Меня коснулись языком");

        SetState(GetComponent<GrabledState>());

        gameObject.transform.SetParent(tongue.transform);
        transform.localPosition = Vector3.zero;

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = _flyGrabbleSound;
        audioSource.Play();
    }


}
