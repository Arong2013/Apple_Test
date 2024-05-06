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
    public AudioSource MainBGM;
    public AudioClip[] Musics;
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
            if(G_S == Game_State.Game_Start)
            {
                if(MainBGM.clip != Musics[0])
                {
                    MainBGM.clip = Musics[0];
                    MainBGM.Play();
                }

            }

        }

        


        if(G_S == Game_State.Fever_Time)
        {
            Fever_Mode();
            if (MainBGM.clip != Musics[1])
            {
                MainBGM.clip = Musics[1];
                MainBGM.Play();
            }
           
        }


        if (G_S == Game_State.Game_Over)
        {
            MainBGM.clip = Musics[0];
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

            //�̰� �ݺ��ؼ� ����Ǵ°� �ƴ϶� �ѹ��� ����Ǿ� ��
            //�ٵ� ���� �̷��� �ع����� �ݺ��ؼ� ��� ����Ǽ� �ٸ� ������� �ذ��������
        }
    }

    void Check_ChildCount() //�迭�ȿ� ���� ������Ʈ�� ���� ������Ʈ���� ���������� �־��ݴϴ�.
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Apples_List[i] == null)
            {
                Apples_List[i] = transform.GetChild(i).gameObject; 
            }

            if(Apples_List[Apples_List.Count-1] != null)
            {
                Apples_List.Add(null);//null ���� ����־ �߰�
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
        Give_Score_num.text = "��������\n" + Apple_score;
    }

    void Fever_Mode()
    {
        Fever_Effect_Panel.SetActive(true);
        Fever_Check.Fever.fillAmount -= 0.1f * Time.deltaTime;
        //UIManager.Instance.Fever_Mode();
        if(Fever_Check.Fever.fillAmount <= 0)
        {
            Fever_Effect_Panel.SetActive(false);
            G_S &= ~Game_State.Fever_Time;//�÷��׷� �ش� ���¸� ������ ������ϴµ� ���� ����ִ� Game_Start���µ� ���� ������ �Ǿ����
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
                yield return new WaitForSeconds(0.5f);
                Vector2 Destroy_Pos = new Vector2(transform.GetChild(0).transform.position.x, transform.GetChild(0).transform.position.y);
                Instantiate(Destroy_EF, Destroy_Pos, Quaternion.identity).transform.parent = null;
                Destroy(transform.GetChild(0).gameObject);
                //���⼭ �߰��� ���ŵɶ� ����Ʈ ���� �� ���� ����
            }
            GameManager.Instance.GameOver();
    }

    //IEnumerator Fever_Mode()
    //{
    //    Fever_Effect_Panel.SetActive(true);
    //    Fever_Check.Fever.fillAmount -= 0.1f * Time.deltaTime;
    //    UIManager.Instance.Fever_Mode();
    //    //�ǹ� �������� 10�� ���� ������ �����ϵ��� ������ֱ�
    //    //�ǹ� ȭ�� ���� ��ũ��Ʈ
    //    //���� 2�� ���������ֵ��� ����� �Լ�
    //    //���� ȭ�鿡 ���� �������� ���� 2�� �����ִ� �ý���
    //    //�ǹ��� ���� ����� ���ĵ� �ǹ� �������� ������ �ʵ��� ��������� + �̰� �ٵ� ��� ������Ʈ���� üũ�ϵ��� �ص� �ɵ�
    //    yield return new WaitForSeconds(10f);
    //    Fever_Effect_Panel.SetActive(false);
    //    G_S &= ~Game_State.Fever_Time;//�÷��׷� �ش� ���¸� ������ ������ϴµ� ���� ����ִ� Game_Start���µ� ���� ������ �Ǿ����
    //    G_S = Game_State.Game_Start;
    //    GameManager.Instance.FeverInitialize();
    //    UIManager.Instance.Normal_mode();
    //    Debug.Log("�ѹ��� ����ǳ����");
    //    yield break;
    //    //���Ӹ޴��� ��ũ��Ʈ�� �ǹ� ī��Ʈ �ʱ�ȭ���ִ� �Լ� �ʿ���

    //    //���δ� ���� ���·� �ʱ�ȭ
    //    //�ǹ� ȭ�� ���ְ� 
    //    //������ ������� �������� 
    //    //��� �������� �ٽ� ������ ��������


    //    //


    //}





}


