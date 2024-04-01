using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI Score;

    [SerializeField] GameObject EscUI;

    public void Start()
    {
    }

    public void Update()
    {
        Score.text =  "현재 점수" + GameManager.Instance.Score.ToString();
    }
}
