using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSequence : MonoBehaviour
{

    [SerializeField] private GameObject[] numbers;

    void Start()
    {
        if (numbers.Length == 0) Debug.LogError("No numbers assigned to the StartingSequence script.");

        StartCoroutine(StartSequence());
        Time.timeScale = 0;   
    }

    private IEnumerator StartSequence()
    {
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i].SetActive(true);
            yield return new WaitForSecondsRealtime(1);
            numbers[i].SetActive(false);
        }

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
