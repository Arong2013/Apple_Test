using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Line_ : MonoBehaviour
{
    float TTime = 0f;
    LineRenderer Death_L;
    public GameObject GameOver_panel;
    public Transform[] Walls = new Transform[2];
    Vector3[] Walls_pos = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        Death_L = GetComponent<LineRenderer>();
        for(int i=0; i<2; i++)
        {
            Walls_pos[i] = new Vector3(Walls[i].position.x,transform.position.y,transform.position.z);
        }
        Death_L.SetPositions(Walls_pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TTime += Time.deltaTime;
        if(TTime >2f)
        {
            Debug.Log("���ӿ���");
<<<<<<< HEAD
            GameManager.Instance.GameOver();
            //Destroy(this.gameObject);
            GS.Game_is_Over();
=======
            Time.timeScale = 0;
            GameOver_panel.SetActive(true);
>>>>>>> main
        }
        //���� �ش� ������Ʈ�� ����ȭ �����ִ� ��ũ��Ʈ
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TTime = 0f;
    }


}
