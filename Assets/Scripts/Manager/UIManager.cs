using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI Score;
    public GameObject MainMenu;
    public Button Retry;
    public Button Quit;


    public void Update()
    {
        Score.text =  "현재 점수" + GameManager.Instance.Score.ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }




    public void Game_Quit()
    {
        Application.Quit();
    }

}
