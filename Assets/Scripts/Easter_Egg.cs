using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Easter_Egg : MonoBehaviour
{
    int click_count = 0;
    public Sprite Duck;
    public Image BackGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(click_count >= 10)
        {
            BackGround.sprite = Duck;
        }
    }

    public void Count()
    {
        click_count++;
        Debug.Log(click_count);
    }

}
