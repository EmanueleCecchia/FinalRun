using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [SerializeField] private bool _canInteract;
    public bool canInteract => _canInteract;

    public Animator _gateAnimator;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public bool Interact(Interactor interactor)
    {
        _animator.SetTrigger("Pull");
        if (_gateAnimator != null) _gateAnimator.SetTrigger("Open");
        _canInteract = false;
        return true;
    }
}
