using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Next_Apple : MonoBehaviour
{
    public Drop_Apple Player;
    Image Apple_img;
    public Sprite[] sprites = new Sprite[4];
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        Apple_img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        num = Player.SetrandNum();
        //¿ÖÁö
        if(num<5)
        {
            Apple_img.sprite = sprites[num];
        }
        
    }

    


}
