using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{

    public void RestartGame()
    {   
        SceneManager.LoadScene("Castle");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
