using StarterAssets;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed = 4f;
    public float detectionRange = 15f;
    public float fovRange = 22f;
    public float fieldOfViewAngle = 45f;

    private GameObject player;
    private ThirdPersonController playerController;
    private Transform playerTransform;
    private Quaternion originalEnemyRotation;

    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private float respawnDelay = 1f;
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private GameObject respawnCanvas;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<ThirdPersonController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null) Debug.LogError("Player not found. Make sure the player has the correct tag.");

        originalEnemyRotation = transform.rotation;
        respawnCanvas.SetActive(false);
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            if ((distanceToPlayer <= detectionRange && !playerController.Crouched) || InFieldOfView(distanceToPlayer, directionToPlayer))
            {
                RotateToPlayer(directionToPlayer);
                SetChildrenActive();
                StartCoroutine(Respawn());
            }
            else
            {
                ReturnToOriginalState();
            }
        }
    }

    bool InFieldOfView(float distanceToPlayer, Vector3 directionToPlayer)
    {
        if (distanceToPlayer <= fovRange)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    void RotateToPlayer(Vector3 directionToPlayer)
    {
        directionToPlayer.y = 0f; // Prevents enemy from tilting up or down
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void SetChildrenActive()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    void SetChildrenInactive()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        respawnCanvas.SetActive(true);
        playerTransform.position = respawnPosition;
        yield return new WaitForSeconds(respawnTime);
        respawnCanvas.SetActive(false);
    }

    void ReturnToOriginalState()
    {
        SetChildrenInactive();
        transform.rotation = Quaternion.Slerp(transform.rotation, originalEnemyRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw FOV ranges
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fovRange);

        // Draw field of view cone
        Gizmos.color = Color.red;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-fieldOfViewAngle * 0.5f, transform.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(fieldOfViewAngle * 0.5f, transform.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;

        Gizmos.DrawLine(transform.position, transform.position + leftRayDirection * fovRange);
        Gizmos.DrawLine(transform.position, transform.position + rightRayDirection * fovRange);
    }
}
