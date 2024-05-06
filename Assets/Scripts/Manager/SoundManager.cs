using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip[] Sounds;
    public AudioSource audio;

    public void ClickSound()
    {
        audio.clip = Sounds[0];
        audio.Play();
    }
    
}
