using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamLaunch : MonoBehaviour
{
    public float maxLaunchForce = 10f;
    public float launchDuration = 1f;

    private CharacterController characterController;
    private bool isLaunching = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null) Debug.LogError("CharacterController component not found!");
    }

    void OnTriggerStay(Collider other)
    {
        if (!isLaunching && other.CompareTag("Position Modifier"))
        {
            StartCoroutine(LaunchCharacter());
        }
    }

    IEnumerator LaunchCharacter()
    {
        isLaunching = true;
        float timer = 0f;

        while (timer < launchDuration)
        {
            float currentLaunchForce = Mathf.Lerp(maxLaunchForce, 0, timer / launchDuration);
            Vector3 launchDirection = transform.up * currentLaunchForce;

            characterController.Move(launchDirection * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }

        isLaunching = false;
    }
}
