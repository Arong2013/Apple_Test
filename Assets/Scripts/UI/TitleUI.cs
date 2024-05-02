using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button startBtn, CreditBtn;

    [SerializeField] TextMeshProUGUI inputField;

    [SerializeField] GameObject Credit;



    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            if (inputField.text != "")
                MainManager.Instance.GoToPlayScene(inputField.text);
            else
            {
                Debug.Log("이름 입력");
            }
        });
        CreditBtn.onClick.AddListener(() =>
{
    if (Credit.gameObject.activeSelf)
        Credit.SetActive(false);
    else
        Credit.SetActive(true);

});

    }
}

