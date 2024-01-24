using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool canInteract { get; }
    public string InteractionPrompt { get; }
    public bool Interact(Interactor interactor);
}
