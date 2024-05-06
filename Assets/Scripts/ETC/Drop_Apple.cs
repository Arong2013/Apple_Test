using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Apple : MonoBehaviour
{
    public GameObject[] Apple;
    public GameObject System;
    public Game_System G_S;
    public GameObject next_Apple;
    //public Transform Wall_L;

    float[] Walls_X = new float[2];

    Show_Next_Apple S_N_A;

    bool isclicked = false;
    bool isApple = false;
    bool DoRandom = true;
    int rand_num;
    float ttime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Apple, transform).transform.parent = System.transform;
        Instantiate(Apple[0], transform).transform.parent = transform;
        Walls_X[0] = G_S.Set_Wall_X_pos();
        Walls_X[1] = -Walls_X[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            isclicked = false;
        }

        if (G_S.G_S == Game_System.Game_State.Game_Start || G_S.G_S == Game_System.Game_State.Fever_Time && Time.timeScale != 0) //���θ޴� �����ִ� ���� �ش� ��ũ��Ʈ�� �������� �ʵ���
        {
            IsApple_Grab();
        }

    }

    void IsApple_Grab()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isclicked = true;


        }

        if (Input.GetMouseButtonUp(0) && isclicked == true)
        {
            if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 21)
            {
                //���콺 ���� ��ư�� ������ ���÷��� �� ���� ������Ʈ�� �״� ��� ������Ʈ�� �ý��� ������Ʈ�� ���� ������Ʈ�� �����Ŵ
                if (isApple == false)
                {

                    isApple = true; //���� ������Ʈ�� ��� ������Ʈ�� �Ѱ������Ƿ� �װ� üũ�ϱ����� ����� isApple�� true��Ŵ
                }
                if (transform.childCount > 0)
                {
                    transform.GetChild(0).parent = System.transform;
                }
                isclicked = false;


            }

        }


        if (isApple == true) //2.5���� ��� ������Ʈ�� �ڽ��� ���� ������Ʈ�� ������Ŵ
        {

            ttime += Time.deltaTime;

            if (ttime >= 0.5f)
            {
                Choose_Apple(rand_num);
                next_Apple.SetActive(false);
                isApple = false;
                DoRandom = true;
                ttime = 0f;

                if (DoRandom == true)
                {
                    Setting_random();
                    //Debug.Log(rand_num);
                    DoRandom = false;
                    next_Apple.SetActive(true);
                }
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


////if(Input.GetMouseButtonDown(0))
////{
////    if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < Walls_X[1] && isApple == false)
////    {
////        already_clicked = true;
////    }
////}
//if (Input.GetMouseButtonUp(0))
//{
//    if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) < 15)
//    {
//        //���콺 ���� ��ư�� ������ ���÷��� �� ���� ������Ʈ�� �״� ��� ������Ʈ�� �ý��� ������Ʈ�� ���� ������Ʈ�� �����Ŵ
//        if (isApple == false)
//        {
//            isApple = true; //���� ������Ʈ�� ��� ������Ʈ�� �Ѱ������Ƿ� �װ� üũ�ϱ����� ����� isApple�� true��Ŵ
//        }
//        if (transform.childCount > 0)
//        {
//            transform.GetChild(0).parent = System.transform;
//        }
//        //already_clicked = false;
//    }
//            //else if(already_clicked == true)
//            //{
//            //    Debug.Log("�̹� Ŭ���߾���");
//            //    //���콺 ���� ��ư�� ������ ���÷��� �� ���� ������Ʈ�� �״� ��� ������Ʈ�� �ý��� ������Ʈ�� ���� ������Ʈ�� �����Ŵ
//            //    if (isApple == false)
//            //    {
//            //        isApple = true; //���� ������Ʈ�� ��� ������Ʈ�� �Ѱ������Ƿ� �װ� üũ�ϱ����� ����� isApple�� true��Ŵ
//            //    }
//            //    if (transform.childCount > 0)
//            //    {
//            //        transform.GetChild(0).parent = System.transform;
//            //    }
//            //    already_clicked = false;
//            //}