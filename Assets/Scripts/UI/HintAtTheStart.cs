using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAtTheStart : MonoBehaviour
{
    [SerializeField] private GameObject hintCanvas;
    [SerializeField] private int hintDuration = 4;
    public string hintText = "A lever is on the roofs";

    void Start()
    {
        hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
        StartCoroutine(Hint());
    }

    IEnumerator Hint()
    {
        yield return new WaitForSeconds(1);
        hintCanvas.SetActive(true);
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
