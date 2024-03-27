using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplePie_score : MonoBehaviour
{

    TextMeshProUGUI Score;
    int score_num = 0;
    int Get_score = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Score = GetComponent<TextMeshProUGUI>();
        //Score.text = "현재점수" + score_num;
    }

    // Update is called once per frame
    void Update()
    {
        if(Get_score > score_num)
        {
            //Score.text = "현재점수 : " + Get_score;
            //StartCoroutine()

        }
        
    }

    public void GetSCore(int scr)
    {
        Get_score = scr;
    }


    //IEnumerator Counting_Score()
    //{

    //}


}
