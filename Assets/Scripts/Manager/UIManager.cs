using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI Score;


    public void Update()
    {
        Score.text =  "현재 점수" + GameManager.Instance.Score.ToString();
    }
}
