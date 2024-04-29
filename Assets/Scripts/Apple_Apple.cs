using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Apple : MonoBehaviour
{
    int count; public int Count => count;

    [SerializeField] int cout;
    int coin;
    int apple;
    int hello;
    int hello2; int hello3;
    public bool crash = false;
    bool already_clicked = false;
    bool Merge = false;

    Vector3 middle_pos = Vector3.zero;

    public GameObject Score_text;
    public GameObject next_Apple;
    public GameObject Merge_effect;
    public GameObject Crash_Obj;
    public Game_System G_S;

    Drop_Apple D_A;

    Rigidbody2D apple_rigid;
    int Apple_Score = 1;
    int Fever_Count = 0;

    float TTime =0;

    public enum Apple_Grab_State
    { 
        None,
        Grab,
        UnGrab,
        Merged,
        GameOver
    };

    public enum Apple_state
    {
        first =1,
        second,
        thrid,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth
    };


    public Apple_state A_S;

    public Apple_Grab_State A_G_S;

    void Start()
    {
        apple_rigid = GetComponent<Rigidbody2D>();
        G_S = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_System>();

        

        //Check_name();
        CheckState();
        if (A_G_S == Apple_Grab_State.Merged)
        {
            Instantiate(Merge_effect, transform);
        }

    }

    void Update()
    {
        if(G_S.G_S == Game_System.Game_State.Game_Start || G_S.G_S == Game_System.Game_State.Fever_Time)
        {
            Check_name();

            if (A_G_S == Apple_Grab_State.Grab)
            { 
                IsGrab();
            }


            if (crash == true && A_S != Apple_state.eighth)
            {
                Apple_Contact(Crash_Obj);
            }
        }
        
        
    }

    void Check_name()
    {
        if (transform.parent.name == "Player")
        {
            A_G_S = Apple_Grab_State.Grab;
        }

        if (transform.parent.name == "System")
        {
            A_G_S = Apple_Grab_State.UnGrab;
            apple_rigid.gravityScale = 4;
        }
    }

    public void IsGrab()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 16f)
            {
                already_clicked = true;
                //Debug.Log("???????? ???????");

            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 16f)
            {
                //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                Vector2 Test = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -16f, 16f), transform.position.y);
                //Clamp 함수의 최소 최대 값 수정해서 이상하게 될 수도 있음 체크
                //apple_rigid.transform.position = Vector2.Lerp(transform.position, Test, 20 * Time.deltaTime);
                apple_rigid.MovePosition(Test); //뭔가 이상해요
                already_clicked = false;
            }
            
        }
    }


    void Apple_Contact(GameObject crash_obj)
    {
        if(crash == true)
        {
            if(transform.position.x < crash_obj.transform.position.x || transform.position.y < crash_obj.transform.position.y)
            {
                if (Merge == false)
                {
                    middle_pos = new Vector3((crash_obj.transform.position.x + transform.position.x) / 2, (crash_obj.transform.position.y + transform.position.y) / 2 - 1, 0); //?颯��?을 ???漫? ?獵??? ???? ?役???? ?茄???
                    Merge = true;
                }
                apple_rigid.constraints = RigidbodyConstraints2D.FreezePosition;
                crash_obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                Vector3.Lerp(crash_obj.transform.position, middle_pos, 100* Time.deltaTime);
                Vector3.Lerp(transform.position, middle_pos, 100 * Time.deltaTime);
                TTime += 2 * Time.deltaTime;
                if(TTime >=0.3f)//?析?? ??????
                {
                    //GameManager.Instance.AddAppleScore((int)A_S); 
                    Destroy(crash_obj.gameObject);
                    Instantiate(next_Apple, middle_pos, Quaternion.identity, transform.parent);
                    //GameManager.Instance.AddAppleScore((int)A_S);
                    if(G_S.G_S != Game_System.Game_State.Fever_Time)
                    {
                        GameManager.Instance.AddAppleScore((int)A_S * 2);
                        GameManager.Instance.AddFeverCount(Fever_Count);
                        
                    }
                    else
                    {
                        GameManager.Instance.AddAppleScore((int)A_S*4);
                    }
                    
                    Destroy(this.gameObject);



                    crash = false;
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == transform.tag)
        {
            crash = true;
            Crash_Obj = collision.gameObject;
            
        }

        if (collision.CompareTag("LWall"))
        {
            //이동하는 함수를 잠시 멈춤
        }
        else if(collision.CompareTag("RWall"))
        {
            //이동하는 함수를 잠시 멈춤
        }
    }

    void CheckState()
    {
        switch (A_S)
        {
            case Apple_state.first:
                {
                    //?? ???쨍????? ?羞???정을 ????
                    Apple_Score = 1;
                    Fever_Count = 1;
                    break;
                }
                
            case Apple_state.second:
                {
                    Apple_Score = 2;
                    Fever_Count = 2;
                    break;
                }
                
            case Apple_state.thrid:
                {
                    Apple_Score = 4;
                    Fever_Count = 3;
                    break;
                }
                
            case Apple_state.fourth:
                {
                    Apple_Score = 8;
                    Fever_Count = 4;
                    break;
                }
                
            case Apple_state.fifth:
                {
                    Apple_Score = 16;
                    Fever_Count = 5;
                    break;
                }

            case Apple_state.sixth:
                {
                    Apple_Score = 32;
                    Fever_Count = 6;
                    break;
                }

            case Apple_state.seventh:
                {
                    Apple_Score = 64;
                    Fever_Count = 7;
                    break;
                }

            case Apple_state.eighth:
                {
                    Apple_Score = 128;
                    Fever_Count = 8;
                    break;
                }
        }
    }

    public void Set_State_gameOver()
    {
        A_G_S = Apple_Grab_State.GameOver;
    }

    //void Set_State_num()
    //{
    //    if(G_S.check_Now_State > (int)A_S)
    //    {
    //        G_S.check_Now_State = (int)A_S;
    //    }
    //}
    


}
