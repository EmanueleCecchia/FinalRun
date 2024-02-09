using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCars : MonoBehaviour
{

    public GameObject carPrefab;
    public float minRespawnDelay = 1.0f;
    public float maxRespawnDelay = 3.0f;

    private Vector3 respawnPosition;

    void Start()
    {
        respawnPosition = transform.position;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        while (true)
        {
            float randomDelay = Random.Range(minRespawnDelay, maxRespawnDelay);
            yield return new WaitForSeconds(randomDelay);
            Instantiate(carPrefab, respawnPosition, Quaternion.Euler(0f, -90f, 0f));
        }
    }
    
}
