using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockLevelsInOrder : MonoBehaviour
{
    public GameObject forestButton;
    public GameObject castleButton;
    public GameObject cityButton;

    public Color disabledTextColor = Color.gray;

    private void Start()
    {
        SetButtonState(forestButton, "BestTimeTutorial");
        SetButtonState(castleButton, "BestTimeForest");
        SetButtonState(cityButton, "BestTimeCastle");
    }

    private void SetButtonState(GameObject currentLevelButtonObject, string previousLevelBestTimeKey)
    {
        if (currentLevelButtonObject == null)
            return;

        Button button = currentLevelButtonObject.GetComponent<Button>();
        if (button == null)
            return;

        TextMeshProUGUI buttonText = currentLevelButtonObject.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText == null)
            return;

        if (PlayerPrefs.GetFloat(previousLevelBestTimeKey) == 0)
        {
            button.interactable = false;
            buttonText.color = disabledTextColor;
        }
        else
        {
            button.interactable = true;
        }
    }
}
