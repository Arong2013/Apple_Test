using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Line_ : MonoBehaviour
{
    float TTime = 0f;
    LineRenderer Death_L;
    public Game_System GS;
    public Transform[] Walls = new Transform[2];
    Vector3[] Walls_pos = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        Death_L = GetComponent<LineRenderer>();
        for(int i=0; i<2; i++)
        {
            Walls_pos[i] = new Vector3(Walls[i].position.x,24,transform.position.z);
        }
        Death_L.SetPositions(Walls_pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.transform.parent.name == "System")
        //{
        //    TTime += Time.deltaTime;
        //    if (TTime > 2f)
        //    {
        //        // GameManager.Instance.GameOver();
        //        Destroy(gameObject);
        //        GS.Game_is_Over();
        //    }
        //}
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TTime = 0f;
    }


}
