using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_check : MonoBehaviour
{
    float TTime = 0f;
    public GameObject Dead_Line;
    // Start is called before the first frame update
    void Start()
    {
        //Dead_Line = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TTime += Time.deltaTime;
        if(TTime > 3f)
        {
            Dead_Line.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TTime = 0f;
    }


}
