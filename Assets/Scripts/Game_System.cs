using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[SerializeField]
public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[5];
    public GameObject Destroy_EF;
    public GameObject Game_Over_panel;
    public GameObject Wall_L;
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;
    bool check_Destroy = false;


    public enum Game_State
    {
        Game_Start = 10,
        Game_Over = 50
    };

    public Game_State G_S = Game_State.Game_Start;

    void Start()
    {
        Apples_List = new List<GameObject>(Apples);
        
    }

    void Update()
    {
        Game_State_Control();

    }

    void Game_State_Control()
    {
        if (G_S == Game_State.Game_Start)
        {
            Check_ChildCount();
        }

        if (G_S == Game_State.Game_Over)
        {
            int count = transform.childCount;

            if (check_Destroy == false && count >0)
            {
                StartCoroutine(Destroy_childObj(count));
                check_Destroy = true;
            }

            if (count == 0)
            {
                Game_Over_panel.SetActive(true);
            }

            //이게 반복해서 실행되는게 아니라 한번만 실행되야 함
            //근데 지금 이렇게 해버리며 반복해서 계속 실행되서 다른 방법으로 해결해줘야함
        }
    }

    void Check_ChildCount() //배열안에 현재 오브젝트의 하위 오브젝트들을 순차적으로 넣어줍니다.
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Apples_List[i] == null)
            {
                Apples_List[i] = transform.GetChild(i).gameObject; 
            }

            if(Apples_List[Apples_List.Count-1] != null)
            {
                Apples_List.Add(null);//null 값을 집어넣어서 추가
            }
            //if(Apples_List.)
        }
    }

    public void Game_is_Over()
    {
        G_S = Game_State.Game_Over;
    }

    public float Set_Wall_X_pos()
    {
        return Wall_L.transform.position.x;
    }

    public void Get_Score(int num)
    {
        Apple_score += num;
        Give_Score_num.text = "현재점수\n" + Apple_score;
    }

    IEnumerator Destroy_childObj(int count )
    {
        //int count = transform.childCount;

            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(1f);
                Vector2 Destroy_Pos = new Vector2(transform.GetChild(0).transform.position.x, transform.GetChild(0).transform.position.y);
                Instantiate(Destroy_EF, Destroy_Pos, Quaternion.identity).transform.parent = null;
                Destroy(transform.GetChild(0).gameObject);
                //여기서 추가로 제거될때 이펙트 생성 및 점수 증가
            }
    }
}


