using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroying " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroying " + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
