using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAtTheStart : MonoBehaviour
{
    public string hintText = "A lever is on the roofs";

    [SerializeField] private GameObject hintCanvas;

    [Tooltip("If true delay and hintDuration wil not be considered")]
    [SerializeField] private bool alwaysShow = false;

    [SerializeField] private float delay = 1;
    [SerializeField] private float hintDuration = 4;

    void Start()
    {
        hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
        if (!alwaysShow) 
            StartCoroutine(Hint());
        else
            hintCanvas.SetActive(true);
    }

    IEnumerator Hint()
    {
        yield return new WaitForSeconds(delay);
        hintCanvas.SetActive(true);
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
