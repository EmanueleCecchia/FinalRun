using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [SerializeField] private bool _canInteract;
    public bool canInteract => _canInteract;

    public GameObject _gate;
    private Animator _gateAnimator;
    private AudioSource _gateSound;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _gateAnimator = _gate.GetComponent<Animator>();
        _gateSound = _gate.GetComponent<AudioSource>();
    }

    public bool Interact(Interactor interactor)
    {
        _animator.SetTrigger("Pull");
        if (_gateAnimator != null) _gateAnimator.SetTrigger("Open");
        if (_gateSound != null) _gateSound.Play();
        _canInteract = false;
        return true;
    }
}
