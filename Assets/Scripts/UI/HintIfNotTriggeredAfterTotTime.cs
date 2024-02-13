using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintIfNotTriggeredAfterTotTime : MonoBehaviour
{
    public string hintText = "Try using the steam";

    [SerializeField] GameObject hintCanvas;
    [SerializeField] float timeToWait = 5;
    [SerializeField] private float hintDuration = 4;

    private bool hasBeenTriggered = false;

    void Start()
    {
        StartCoroutine(WaitAndShowHint());
    }

    void OnTriggerEnter(Collider other)
    {
        hasBeenTriggered = true;
    }

    IEnumerator WaitAndShowHint()
    {
        yield return new WaitForSeconds(timeToWait);

        if (!hasBeenTriggered)
        {
            hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
            hintCanvas.SetActive(true);
            StartCoroutine(CloseHint());
        }
    }

    IEnumerator CloseHint()
    {
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
