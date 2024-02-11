using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintOneTimeTrigger : MonoBehaviour
{
    public string hintText = "Press M to open the Menu";

    [SerializeField] private GameObject hintCanvas;

    [Tooltip("If true hintDuration wil not be considered")]
    [SerializeField] private bool alwaysShow = false;

    [SerializeField] private float hintDuration = 4;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
            hintCanvas.SetActive(true);
            if (!alwaysShow) StartCoroutine(CloseHint());
        }
    }

    IEnumerator CloseHint()
    {
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
