using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drowining : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private GameObject respawnCanvas;

    void Start()
    {
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
