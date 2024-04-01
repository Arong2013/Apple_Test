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
        Score.text =  "���� ����" + GameManager.Instance.Score.ToString();
    }
}
