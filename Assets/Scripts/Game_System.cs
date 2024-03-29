using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[SerializeField]
public class Game_System : MonoBehaviour
{
    public GameObject[] Apples = new GameObject[5];
    public GameObject Destroy_EF;
    public List<GameObject> Apples_List; 
    public int check_Now_State = 1;
    public int Apple_score = 0;
    public TextMeshProUGUI Give_Score_num;
    bool check_Destroy = false;
    float D_time = 0f;


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
        if(G_S == Game_State.Game_Start)
        {
            Check_ChildCount();
        }
        
        if(G_S == Game_State.Game_Over)
        {
            if(check_Destroy == false)
            {
                StartCoroutine(Destroy_childObj());
                check_Destroy = true;
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

    public void Get_Score(int num)
    {
        Apple_score += num;
        Give_Score_num.text = "��������\n" + Apple_score;
    }

    IEnumerator Destroy_childObj()
    {
        int count = transform.childCount;
        
        for(int i=0; i<count; i++)
        {
            yield return new WaitForSeconds(2f);
            Destroy(transform.GetChild(0).gameObject);
            //���⼭ �߰��� ���ŵɶ� ����Ʈ ���� �� ���� ����
        }
                
        
        
    }

}
