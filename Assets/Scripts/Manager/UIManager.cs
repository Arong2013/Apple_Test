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
    public GameObject Best_Score;

    string Name;

    [SerializeField] GameObject EscUI;
    [SerializeField] GameObject rankUI; public GameObject RankUI => rankUI;

    public void Start()
    {
        //Name = FindObjectOfType<Name>().SetName();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Pixel_Modifying_Play_Scene")
        {
            Score.text = "현재 점수\n" + GameManager.Instance.Score.ToString();
            Score_GameOver.text = GameManager.Instance.Score.ToString() + " " + Name; // + �߰��� �������� �־������
            if (System.G_S != Game_System.Game_State.Fever_Time)
            {
                Fever_Fill(); //�ǹ�Ÿ���϶� ���� ��ȭ ����
            }





            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MainMenu.SetActive(true);
                Time.timeScale = 0;
            }
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
            float fillnow = Fever.fillAmount;
            Fever.fillAmount = Mathf.Lerp(fillnow, (float)GameManager.Instance.Fever / 50f, Time.deltaTime * 20f);
            //Fever.fillAmount = (float)GameManager.Instance.Fever / 50f;
        }
        else
        {
            System.G_S |= Game_System.Game_State.Fever_Time;

        }
    }


    public void Restart()
    {
        Destroy(GameManager.Instance.gameObject);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Pixel_Modifying_Play_Scene");
        Time.timeScale = 1;
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title_Scene");
    }


    public void Game_Quit()
    {
        Application.Quit();
    }

}
