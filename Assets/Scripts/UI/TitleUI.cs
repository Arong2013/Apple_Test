using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button startBtn, CreditBtn, RankBtn, MenuBtn;

    [SerializeField] TMP_InputField name_inputField;

    [SerializeField] TextMeshProUGUI inputField;

    [SerializeField] GameObject Credit, RankUI, MainMenu;



    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            if (!String.IsNullOrEmpty(inputField.text))
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

        RankBtn.onClick.AddListener(() =>
         {
             if (RankUI.gameObject.activeSelf)
                 RankUI.SetActive(false);
             else
                 RankUI.SetActive(true);
         });

        MenuBtn.onClick.AddListener(() =>
        {
            if (MainMenu.gameObject.activeSelf)
                MainMenu.SetActive(false);
            else
                MainMenu.SetActive(true);

        });


        name_inputField.onEndEdit.AddListener((aa) =>
        {
            MainManager.Instance.GoToPlayScene(this.inputField.text);


        }
        );


    }

    void ValueChanged(string text)
    {
        Debug.Log(text);
    }








}

