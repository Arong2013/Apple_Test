using System;
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
    public GameObject Fever_Effect_Panel;
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;
    public UIManager Fever_Check;
    bool check_Destroy = false;

    [Flags]
    public enum Game_State
    {
        Game_Start = 10,
        Fever_Time =30,
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
        if (G_S == Game_State.Game_Start || G_S == Game_State.Fever_Time)
        {
            Check_ChildCount();


        }

        if(G_S == Game_State.Fever_Time)
        {
            Fever_Mode();
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

    void Fever_Mode()
    {
        Fever_Effect_Panel.SetActive(true);
        Fever_Check.Fever.fillAmount -= 0.1f * Time.deltaTime;
        //UIManager.Instance.Fever_Mode();
        if(Fever_Check.Fever.fillAmount <= 0)
        {
            Fever_Effect_Panel.SetActive(false);
            G_S &= ~Game_State.Fever_Time;//플래그로 해당 상태만 삭제를 해줘야하는데 원래 들어있는 Game_Start상태도 같이 삭제가 되어버림
            G_S = Game_State.Game_Start;
            GameManager.Instance.FeverInitialize();
            //UIManager.Instance.Normal_mode();
        }
        
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

    //IEnumerator Fever_Mode()
    //{
    //    Fever_Effect_Panel.SetActive(true);
    //    Fever_Check.Fever.fillAmount -= 0.1f * Time.deltaTime;
    //    UIManager.Instance.Fever_Mode();
    //    //피버 게이지가 10초 동안 서서히 감소하도록 만들어주기
    //    //피버 화면 띄우는 스크립트
    //    //점수 2배 증가시켜주도록 만드는 함수
    //    //점수 화면에 기존 점수보다 글자 2배 더해주는 시스템
    //    //피버일 때는 사과를 합쳐도 피버 게이지가 오르지 않도록 막아줘야함 + 이건 근데 사과 오브젝트에서 체크하도록 해도 될듯
    //    yield return new WaitForSeconds(10f);
    //    Fever_Effect_Panel.SetActive(false);
    //    G_S &= ~Game_State.Fever_Time;//플래그로 해당 상태만 삭제를 해줘야하는데 원래 들어있는 Game_Start상태도 같이 삭제가 되어버림
    //    G_S = Game_State.Game_Start;
    //    GameManager.Instance.FeverInitialize();
    //    UIManager.Instance.Normal_mode();
    //    Debug.Log("한번만 실행되나요ㅕ");
    //    yield break;
    //    //게임메니저 스크립트에 피버 카운트 초기화해주는 함수 필요함

    //    //전부다 원래 상태로 초기화
    //    //피버 화면 꺼주고 
    //    //점수도 원래대로 오르도록 
    //    //사과 합쳐질때 다시 게이지 오르도록


    //    //


    //}





}


