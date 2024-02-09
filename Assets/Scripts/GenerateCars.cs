using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCars : MonoBehaviour
{

    public GameObject carPrefab;
    public List<Material> carMaterials = new List<Material>();

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

            GameObject newCar = Instantiate(carPrefab, respawnPosition, Quaternion.Euler(0f, -90f, 0f));

            if (carMaterials.Count > 0)
            {
                Material randomMaterial = carMaterials[Random.Range(0, carMaterials.Count)];
                MeshRenderer renderer = newCar.GetComponent<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material = randomMaterial;
                }
                else
                {
                    Debug.LogWarning("No MeshRenderer found on the carPrefab to apply materials.");
                }
            }
            else
            {
                Debug.LogWarning("No materials specified in the carMaterials list.");
            }
        }
    }
    
}
