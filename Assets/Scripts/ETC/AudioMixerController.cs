using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioMixerController : MonoBehaviour
{
    public AudioMixer GameAudio;
    Slider MyAudioSlider;

    public void Awake()
    {
        MyAudioSlider = gameObject.GetComponent<Slider>();
    }


    public void BGMControl()
    {
        float sound = MyAudioSlider.value;

        if (sound == -40f)
        {
            GameAudio.SetFloat("BGM", -80f);
        }
        else
        {
            GameAudio.SetFloat("BGM", sound);
        }

    }

    public void SFXControl()
    {
        float sound = MyAudioSlider.value;

        if (sound == -40f)
        {
            GameAudio.SetFloat("SFX", -80f);
        }
        else
        {
            GameAudio.SetFloat("SFX", sound);
        }
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

}
