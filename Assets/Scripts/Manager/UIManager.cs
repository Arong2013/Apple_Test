using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Score_GameOver;
    public TextMeshProUGUI[] Normal_txt;
    public TextMeshProUGUI[] Fever_txt;

    public GameObject MainMenu;
    public Game_System System;//�ǹ�Ÿ�� ������ �޾ƿ� �Ŷ� ������ ���� ����
    public Button Retry;
    public Button Quit;
    public Image Fever;

    


    string Name;

    [SerializeField] GameObject EscUI;
    [SerializeField] GameObject rankUI; public GameObject RankUI => rankUI; 

    public void Start()
    {
        //Name = FindObjectOfType<Name>().SetName();
    }

    public void Update()
    {
        Score.text =  "���� ����\n" + GameManager.Instance.Score.ToString();
        Score_GameOver.text = GameManager.Instance.Score.ToString() + " " + Name; // + �߰��� ������ �־������
        if(System.G_S != Game_System.Game_State.Fever_Time)
        {
            Fever_Fill(); //�ǹ�Ÿ���϶� ���� ��ȭ ����
        }
        




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Quit_Menu()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Fever_Fill()
    {
        if (Fever.fillAmount < 1)
        {
            //Debug.Log((float)GameManager.Instance.Fever);
            Fever.fillAmount = (float)GameManager.Instance.Fever / 50f;
        }
        else
        {
            System.G_S |= Game_System.Game_State.Fever_Time;
        }
    }

    public void Fever_Mode()
    {
        for(int i=0; i< Fever_txt.Length; i++)
        {
            Fever_txt[i].gameObject.SetActive(true);
            Normal_txt[i].gameObject.SetActive(false);
        }
    }

    public void Normal_mode()
    {
        for(int i=0; i<Normal_txt.Length; i++)
        {
            Normal_txt[i].gameObject.SetActive(true);
            Fever_txt[i].gameObject.SetActive(false);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("Main_Scene");
        Time.timeScale = 1;
    }


    public void Game_Quit()
    {
        Application.Quit();
    }

}
