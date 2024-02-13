using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider; 
    public string mixerParameterName = "Master";

    private string savedVolumeKey;

    private void Start()
    {
        savedVolumeKey = mixerParameterName + "SavedVolume";
    }

    public void SetVolume()
    {
        mixer.SetFloat(mixerParameterName, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat(savedVolumeKey, slider.value);
    }
}
