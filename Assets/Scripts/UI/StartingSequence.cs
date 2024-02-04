using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingSequence : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    [SerializeField] private int countdownFrom = 3;

    void Start()
    {
        countdownText.text = "";
        StartCoroutine(Countdown());
        Time.timeScale = 0;   
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(1);
     
        for (int i = countdownFrom; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
