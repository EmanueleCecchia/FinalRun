using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAtTheStart : MonoBehaviour
{
    public string hintText = "A lever is on the roofs";

    [SerializeField] private GameObject hintCanvas;

    [Tooltip("If true Hint Duration will not be considered")]
    [SerializeField] private bool alwaysShow = false;

    [SerializeField] private float delay = 1;
    [SerializeField] private float hintDuration = 4;

    void Start()
    {
        hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
        StartCoroutine(Hint());
    }

    IEnumerator Hint()
    {
        yield return new WaitForSeconds(delay);
        hintCanvas.SetActive(true);
        if (!alwaysShow)
        {
            yield return new WaitForSeconds(hintDuration);
            hintCanvas.SetActive(false);
        }
    }
}
