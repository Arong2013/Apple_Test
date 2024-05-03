using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_obj : MonoBehaviour
{
    public Sprite apple1;
    SpriteRenderer mysprite;
    // Start is called before the first frame update
    void Start()
    {
        mysprite = GetComponent<SpriteRenderer>();
        mysprite.sprite = apple1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
