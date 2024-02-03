using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public TextMeshProUGUI castleRecordText;

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
        castleRecordText.text = TimeFromFloatToString(PlayerPrefs.GetFloat("BestTimeCastle"));
    }

    string TimeFromFloatToString(float time)
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        return minutes + ":" + seconds;
    }
}
