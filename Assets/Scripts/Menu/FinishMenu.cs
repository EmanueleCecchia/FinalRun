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

    public void RestartGame()
    {   
        SceneManager.LoadScene("Castle");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        time = PlayerPrefs.GetFloat("Time");
        timeText.text = TimeFromFloatToString(time);

        UpdateBestTimeIfNeeded();

        bestTime = PlayerPrefs.GetFloat("BestTimeCastle");
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
        if (PlayerPrefs.GetFloat("BestTimeCastle") == 0 || time < PlayerPrefs.GetFloat("BestTimeCastle"))
        {
            PlayerPrefs.SetFloat("BestTimeCastle", time);
        }
    }
}
