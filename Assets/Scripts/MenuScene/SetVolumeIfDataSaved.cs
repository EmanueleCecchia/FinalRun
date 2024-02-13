using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Non credo che sia il modo migliore per impostare il volume se ci sono dati salvati (quindi l'utente ha modificato i valori)
// pero' se lo metto nei singoli script dei mixer non funziona
// neanche se lo metto in Awake(), funziona solo se l'utente apre Options e quindi l'oggetto diventa attivo

public class SetVolumeIfDataSaved : MonoBehaviour
{
    [SerializeField] private List<mixerVolume> mixerVolumes = new List<mixerVolume>();

    private void Start()
    {
        foreach (mixerVolume mixerVolume in mixerVolumes)
        {
            mixerVolume.SetVolume();
        }
    }

    [System.Serializable]
    protected class mixerVolume
    {
        public AudioMixer mixer;
        public Slider slider;
        public string mixerParameterName;

        public void SetVolume()
        {
            string savedVolumeKey = mixerParameterName + "SavedVolume";
            if (PlayerPrefs.HasKey(savedVolumeKey) && PlayerPrefs.GetFloat(savedVolumeKey) != 0)
            {
                slider.value = PlayerPrefs.GetFloat(savedVolumeKey);
                mixer.SetFloat(mixerParameterName, Mathf.Log10(slider.value) * 20);
            }
        }
    }
}
