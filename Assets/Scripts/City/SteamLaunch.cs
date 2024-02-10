using System.Collections;
using UnityEngine;

public class SteamLaunch : MonoBehaviour
{
    public float maxLaunchForce = 10f;
    public float launchDuration = 1f;
    public float directionForceMultiplier = 1f; 

    public enum Direction
    {
        Left,
        Right,
        Forward,
        Backward
    }
    [Tooltip("The direction in which the player will be launched, in relation to the object's local space.")]
    public Direction direction;

    private GameObject player;
    private CharacterController characterController;
    private bool isLaunching = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        if (characterController == null) Debug.LogError("CharacterController component not found!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isLaunching && other.CompareTag("Player"))
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
            Vector3 launchUp = transform.up * currentLaunchForce;
            characterController.Move(launchUp * Time.deltaTime);

            Vector3 launchDirection = Vector3.zero;
            switch (direction)
            {
                case Direction.Left:
                    launchDirection += -transform.right * directionForceMultiplier;
                    break;
                case Direction.Right:
                    launchDirection += transform.right * directionForceMultiplier;
                    break;
                case Direction.Forward:
                    launchDirection += transform.forward * directionForceMultiplier;
                    break;
                case Direction.Backward:
                    launchDirection += -transform.forward * directionForceMultiplier;
                    break;
            }
            characterController.Move(launchDirection * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }

        isLaunching = false;
    }
}
