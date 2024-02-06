using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioWhenAnimationFinish : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // When normalizedTime is greater than or equal to 1.0, it means that the animation has completed one full cycle.
        // The !animator.IsInTransition(0) check ensures that the animation is not in a transition phase between states.
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("GateOpening") && !_animator.IsInTransition(0))
        {
            float normalizedTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (normalizedTime >= 1f)
            {
                _audioSource.Stop();
            }
        }
    }
}
