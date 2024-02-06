using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestTimeText;
    private float time = 0f;
    private float bestTime = 0f;
    private string bestTimeKey;

    public void RestartGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        bestTimeKey = "BestTime" + SceneManager.GetActiveScene().name;

        time = PlayerPrefs.GetFloat("Time");
        timeText.text = TimeFromFloatToString(time);

        UpdateBestTimeIfNeeded();

        bestTime = PlayerPrefs.GetFloat(bestTimeKey);
        bestTimeText.text = TimeFromFloatToString(bestTime);

    }

    string TimeFromFloatToString(float time)
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        return minutes + ":" + seconds;
    }

    void UpdateBestTimeIfNeeded()
    {
        float currentBestTime = PlayerPrefs.GetFloat(bestTimeKey);
        if (currentBestTime == 0 || time < currentBestTime)
        {
            PlayerPrefs.SetFloat(bestTimeKey, time);
        }
    }
}
