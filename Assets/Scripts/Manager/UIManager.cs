using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI Score;
    public GameObject MainMenu;
    public Button Retry;
    public Button Quit;

    [SerializeField] GameObject EscUI;
    [SerializeField] GameObject rankUI; public GameObject RankUI => rankUI; 

    public void Start()
    {
    }

    public void Update()
    {
        Score.text =  "현재 점수" + GameManager.Instance.Score.ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main_Scene");
    }


    public void Game_Quit()
    {
        Application.Quit();
    }

}
