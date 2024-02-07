using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject hintCanvas;
    [SerializeField] private int hintDuration = 4;
    public string hintText = "A lever is on the rampart";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hintText;
            hintCanvas.SetActive(true);
            StartCoroutine(Hint());
        }
    }

    IEnumerator Hint()
    {
        yield return new WaitForSeconds(hintDuration);
        hintCanvas.SetActive(false);
    }
}
