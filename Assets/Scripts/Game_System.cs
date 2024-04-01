using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[5];
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;


    public enum System_State
    {
        Apple_01,
        Apple_02,
        Apple_03,
        Apple_04,
    };


    public System_State Apple_State = System_State.Apple_01;

    void Start()
    {
        Apples_List = new List<GameObject>(Apples);
        
    }

    void Update()
    {
        Check_ChildCount();


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

    public void Get_Score(int num)
    {
        Apple_score += num;
        Give_Score_num.text = "현재점수\n" + Apple_score;
    }

}
