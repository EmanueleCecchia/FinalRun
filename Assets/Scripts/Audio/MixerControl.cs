using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider; 
    public string mixerParameterName = "Master";

    public void SetVolume()
    {
        float sliderValue = slider.value;
        mixer.SetFloat(mixerParameterName, Mathf.Log10(sliderValue) * 20);
    }
}
