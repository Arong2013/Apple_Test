using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Apple : MonoBehaviour
{
    public GameObject[] Apple;
    public GameObject System;
    public Game_System G_S;
    public GameObject next_Apple;

    Show_Next_Apple S_N_A;

    bool already_clicked = false;
    bool isApple = false;
    bool DoRandom = true;
    int rand_num;
    float ttime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Apple, transform).transform.parent = System.transform;
        Instantiate(Apple[0], transform).transform.parent = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        IsApple_Grab();
    }

    void IsApple_Grab()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 11.5f && isApple == false)
            {
                already_clicked = true;
                

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) <11.5f)
            {
                //마우스 왼쪽 버튼을 누르고 들어올렸을 때 하위 오브젝트로 뒀던 사과 오브젝트를 시스템 오브젝트의 하위 오브젝트로 변경시킴
                if (isApple == false)
                {
                    isApple = true; //하위 오브젝트가 사과 오브젝트가 넘겨줬으므로 그걸 체크하기위해 사용한 isApple을 true시킴
                }
                if (transform.childCount > 0)
                {
                    transform.GetChild(0).parent = System.transform;
                }
                already_clicked = false;
            }
            else if(already_clicked == true)
            {
                Debug.Log("이미 클릭했었음");
                //마우스 왼쪽 버튼을 누르고 들어올렸을 때 하위 오브젝트로 뒀던 사과 오브젝트를 시스템 오브젝트의 하위 오브젝트로 변경시킴
                if (isApple == false)
                {
                    isApple = true; //하위 오브젝트가 사과 오브젝트가 넘겨줬으므로 그걸 체크하기위해 사용한 isApple을 true시킴
                }
                if (transform.childCount > 0)
                {
                    transform.GetChild(0).parent = System.transform;
                }
                already_clicked = false;
            }



        }


        if (isApple == true) //2.5초후 사과 오브젝트를 자신의 하위 오브젝트에 생성시킴
        {

            ttime += Time.deltaTime;
            if(DoRandom == true)
            {
                Setting_random();
                //Debug.Log(rand_num);
                DoRandom = false;
            }
            if(ttime >= 0.5f)
            {
                //스프라이트를 넣어줌
                next_Apple.SetActive(true);
            }

            if (ttime >= 2.5f)
            {
                Choose_Apple(rand_num);
                next_Apple.SetActive(false);
                isApple = false;
                DoRandom = true;
                ttime = 0f;
            }
        }
    }

    void Choose_Apple(int r_num)
    {
        switch (G_S.check_Now_State)
        {
            case >= 6:
                {
                    
                    Instantiate(Apple[r_num], transform).transform.parent = transform;
                    break;
                }

            default:
                {
                    
                    Instantiate(Apple[r_num], transform).transform.parent = transform;
                }
                break;
        }
    }

    void Setting_random()
    {
        if (G_S.check_Now_State >= 6)
        {
            rand_num = (int)Random.Range(0f, 4f);
        }
        else
        {
            rand_num = (int)Random.Range(0f, 3f);
        }
    }

    public int SetrandNum()
    {
        return rand_num;
    }

}
