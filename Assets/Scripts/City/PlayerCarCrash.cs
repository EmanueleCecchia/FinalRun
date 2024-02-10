using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCrash : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private float respawnDelay = 1f;
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private GameObject respawnCanvas;
    void Start()
    {
        respawnCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        respawnCanvas.SetActive(true);
        transform.position = respawnPosition;
        yield return new WaitForSeconds(respawnTime);
        respawnCanvas.SetActive(false);
    }
}
