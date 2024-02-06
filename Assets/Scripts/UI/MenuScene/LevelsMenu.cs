using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public TextMeshProUGUI tutorialRecordText;
    public TextMeshProUGUI forestRecordText;
    public TextMeshProUGUI castleRecordText;
    public TextMeshProUGUI cityRecordText;

    public void PlayTutorial()
    {
        LoadScene("Tutorial");
    }

    public void PlayForest()
    {
        LoadScene("Forest");
    }

    public void PlayCastle()
    {
        LoadScene("Castle");
    }

    public void PlayCity()
    {
        LoadScene("City");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //  LoadSceneMode.Single (default) or LoadSceneMode.Additive
    }

    private void Start()
    {
        tutorialRecordText.text = TimeFromFloatToString(PlayerPrefs.GetFloat("BestTimeTutorial"));
        forestRecordText.text = TimeFromFloatToString(PlayerPrefs.GetFloat("BestTimeForest"));
        castleRecordText.text = TimeFromFloatToString(PlayerPrefs.GetFloat("BestTimeCastle"));
        cityRecordText.text = TimeFromFloatToString(PlayerPrefs.GetFloat("BestTimeCity"));
    }

    string TimeFromFloatToString(float time)
    {
        if (time == 0)
        {
            return "/";
        }
        else
        {
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            return minutes + ":" + seconds;
        }
    }
}
