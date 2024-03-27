using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Controller : MonoBehaviour
{
    float TTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TTime += Time.deltaTime;
        if(TTime >1f)
        {
            Destroy(gameObject);
        }
    }

   



}
