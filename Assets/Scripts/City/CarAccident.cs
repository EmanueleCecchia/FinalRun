using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAccident : MonoBehaviour
{
    [SerializeField] private TrafficSignal trafficSignal;

    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private float respawnDelay = 1f;
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private GameObject respawnCanvas;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (trafficSignal.signalState == TrafficSignal.SignalState.Red)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        respawnCanvas.SetActive(true);
        player.transform.position = respawnPosition;
        yield return new WaitForSeconds(respawnTime);
        respawnCanvas.SetActive(false);
    }
}
