using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drowining : MonoBehaviour
{

    private GameObject player;
    private Transform playerTransform;
    private Quaternion originalEnemyRotation;
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private Vector3 respawnPosition;

    [SerializeField] private GameObject respawnCanvas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        respawnCanvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        respawnCanvas.SetActive(true);
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
