using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
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
}
