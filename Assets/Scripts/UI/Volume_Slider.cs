using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Slider : MonoBehaviour
{
    Slider Volume_slider;
    public AudioSource mainbgm;
    // Start is called before the first frame update
    void Start()
    {
        Volume_slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mainbgm.volume = Volume_slider.value;
    }
}
