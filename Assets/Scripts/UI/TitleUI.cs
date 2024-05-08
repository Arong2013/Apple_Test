using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button startBtn, CreditBtn, RankBtn, MenuBtn,QuitBtn;

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


        name_inputField.onSubmit.AddListener((aa) =>
        {
            if (name_inputField.text.Length !=0 && name_inputField.text != " ")
            {
                Debug.Log("this.inputField.text.Length : " + name_inputField.text.Length);
                MainManager.Instance.GoToPlayScene(this.inputField.text);
            }
            else
            {
                Debug.Log("입력받은 값이 너무 작습니다.");
            }



        }
        );

        QuitBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.Game_Quit();
        });


    }

    void ValueChanged(string text)
    {
        Debug.Log(text);
    }








}

