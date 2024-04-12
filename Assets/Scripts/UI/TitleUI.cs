using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button startBtn;

    [SerializeField] TextMeshProUGUI inputField;

    

    void Start()
    {
        startBtn.onClick.AddListener(() => 
        {
            if(string.IsNullOrEmpty(inputField.text))
             MainManager.Instance.GoToPlayScene(inputField.text);
             else
             {
                Debug.Log("이름 입력");
             }
             });
    }
}

