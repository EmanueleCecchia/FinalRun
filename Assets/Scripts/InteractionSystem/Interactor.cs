using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactionMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    private StarterAssetsInputs _input;

    public void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactionMask);
        
        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();  
           
            if (_interactable != null && _interactable.canInteract != false)
            {
                HandleInteractionUI();
                HandleInteractInput();
            }
        }
        else
        {
            ClearInteractable();
            CloseInteractionUI();
        }
    }

    private void HandleInteractionUI()
    {
        if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
    }

    private void HandleInteractInput()
    {
        if (_input.interact)
        {
            _interactable.Interact(this);
            if (!_interactable.canInteract) CloseInteractionUI();
            _input.interact = false;
        }
    }

    private void ClearInteractable()
    {
        if (_interactable != null) _interactable = null;
    }

    private void CloseInteractionUI()
    {
        if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
