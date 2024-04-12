using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : Singleton<MainManager>
{
    [SerializeField] string playerName; public string PlayerName => playerName;      
    public void GoToPlayScene(string _name)
    {
        playerName = _name;
        SceneManager.LoadScene("Play_Scene");
    }
}
