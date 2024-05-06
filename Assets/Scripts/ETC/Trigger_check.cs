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
        if(collision.transform.parent.name == "System")
        {
            TTime += Time.deltaTime;
            if (TTime > 1f)
            {
                if (Dead_Line.gameObject != null)
                {
                    Dead_Line.SetActive(true);
                }

            }

            
        }


    }

    private void OnTriggerExit2D(Collider2D collision) //이렇게가 아니라 다른 방법으로 나갔다는 것을 확인 시켜줘야 할 것 같음
    {
        if (collision.transform.parent.name == "System")
        {
            TTime = 0f;
            if (Dead_Line.gameObject != null)
            {
                Dead_Line.SetActive(false);
            }
        }
    }


}
