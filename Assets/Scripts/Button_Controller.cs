using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour
{
    Image b_img;
    public AudioSource mute;
    public Sprite[] sprites = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
        b_img = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite()
    {
        if(b_img.sprite == sprites[0])
        {
            b_img.sprite = sprites[1];
        }
        else
        {
            b_img.sprite = sprites[0];
        }
        
    }
    
    public void SetVolume()
    {
        if(mute.mute == true)
        {
            mute.mute = false;
            mute.Play();
        }
        else
        {
            mute.mute = true;
            mute.Stop();
        }
        
        
    }

}
