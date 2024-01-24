using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public bool Interact(Interactor interactor)
    {
        _animator.SetTrigger("Pull");
        return true;
    }
}
