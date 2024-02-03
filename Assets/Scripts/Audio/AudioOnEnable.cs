using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnEnable : MonoBehaviour
{
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void OnDisable()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
