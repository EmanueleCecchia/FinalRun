using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHint : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [SerializeField] private bool _canInteract;
    public bool canInteract => _canInteract;


    public string hintText = "Press M to open the Menu";
    [SerializeField] private GameObject hintCanvas;
    [SerializeField] private float hintDuration = 4;

    public bool Interact(Interactor interactor)
    {
        hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
        hintCanvas.SetActive(true);
        StartCoroutine(CloseHint());
        _canInteract = false;
        return true;
    }

    IEnumerator CloseHint()
    {
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
