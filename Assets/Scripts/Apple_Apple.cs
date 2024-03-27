using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Apple : MonoBehaviour
{
    public bool crash = false;
    bool already_clicked = false;
    bool Merge = false;

    Vector3 middle_pos = Vector3.zero;

    public GameObject Score_text;
    public GameObject next_Apple;
    public GameObject Merge_effect;
    public GameObject Crash_Obj;
    public Game_System G_S;
    Rigidbody2D apple_rigid;
    int Apple_Score = 1;

    float aa =0;

    public enum Apple_Grab_State
    { 
        None,
        Grab,
        UnGrab,
        Merged
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
        G_S = GetComponentInParent<Game_System>();//그랩 되어있는 변수는 영향을 못받음 그래서 의미가 크게 없음
        //Check_name();
        CheckState();
        if (A_G_S == Apple_Grab_State.Merged)
        {
            Instantiate(Merge_effect, transform);
        }

    }

    void Update()
    {
        Check_name();

        if (A_G_S == Apple_Grab_State.Grab)
        {
            IsGrab();
        }


        if(crash == true && A_S != Apple_state.eighth)
        {
            Apple_Contact(Crash_Obj);
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
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 12f)
            {
                already_clicked = true;
                Debug.Log("어디부터 안됬는지");

            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 12f)
            {
                Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                Vector2 Test = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -9.6f, 9.6f), transform.position.y);
                //x값이 특정 범위를 벗어나면 그대로 맵 밖으로 벗어나기 때문에 일정 값 이하까지만 가능하도록
                //지금 이렇게 만들면 이 위치로 바로 순간이동 해버리기 때문에 이렇게가 아니라 서서히 이동하는 것처럼 보이도록 해야함
                transform.position = Vector2.Lerp(transform.position, Test, 20 * Time.deltaTime);
                already_clicked = false;
            }
            if(already_clicked == true)
            {
                Debug.Log("왜 안되지");
                Vector2 Test = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -9.6f, 9.6f), transform.position.y);
                //x값이 특정 범위를 벗어나면 그대로 맵 밖으로 벗어나기 때문에 일정 값 이하까지만 가능하도록
                //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                //지금 이렇게 만들면 이 위치로 바로 순간이동 해버리기 때문에 이렇게가 아니라 서서히 이동하는 것처럼 보이도록 해야함
                transform.position = Vector2.Lerp(transform.position, Test, 20 * Time.deltaTime);
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
                    middle_pos = new Vector3((crash_obj.transform.position.x + transform.position.x) / 2, (crash_obj.transform.position.y + transform.position.y) / 2 - 1, 0); //중심값을 구해서 최대한 벽에 충돌하지 않도록
                    Merge = true;
                }
                apple_rigid.constraints = RigidbodyConstraints2D.FreezePosition;
                crash_obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                Vector3.Lerp(crash_obj.transform.position, middle_pos, 100* Time.deltaTime);
                Vector3.Lerp(transform.position, middle_pos, 100 * Time.deltaTime);
                aa += 2 * Time.deltaTime;
                if(aa >=0.3f)//약간의 딜레이
                {
                    DestroyAndScore(crash_obj);
                    Instantiate(next_Apple, middle_pos, Quaternion.identity, transform.parent);
                    DestroyAndScore(gameObject);
                    
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
    }

    void CheckState()
    {
        switch (A_S)
        {
            case Apple_state.first:
                {
                    //각 상태마다의 기본 설정을 해줌
                    Apple_Score = 1;
                    break;
                }
                
            case Apple_state.second:
                {
                    Apple_Score = 2;
                    break;
                }
                
            case Apple_state.thrid:
                {
                    Apple_Score = 3;
                    break;
                }
                
            case Apple_state.fourth:
                {
                    Apple_Score = 4;
                    break;
                }
                
            case Apple_state.fifth:
                {
                    Apple_Score = 5;
                    break;
                }

            case Apple_state.sixth:
                {
                    Apple_Score = 6;
                    break;
                }

            case Apple_state.seventh:
                {
                    Apple_Score = 7;
                    break;
                }

            case Apple_state.eighth:
                {
                    Apple_Score = 8;
                    break;
                }
        }
    }

    void DestroyAndScore(GameObject myApple)
    {
        if(G_S == null)
        {
            G_S = GetComponentInParent<Game_System>();
        }
        G_S.Get_Score(myApple.GetComponent<Apple_Apple>().Apple_Score);
        Destroy(myApple);

            
    }

    //void Set_State_num()
    //{
    //    if(G_S.check_Now_State > (int)A_S)
    //    {
    //        G_S.check_Now_State = (int)A_S;
    //    }
    //}
    


}
