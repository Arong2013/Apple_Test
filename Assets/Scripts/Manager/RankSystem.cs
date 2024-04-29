using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public struct PlayerInformation
{
    public string playerName;
    public int Score;


    public PlayerInformation(int _score, string _playerName)
    {
        Score = _score;
        playerName = _playerName;
    }
}

public class RankSystem : MonoBehaviour
{
    const string RankURL = "https://script.google.com/macros/s/AKfycbx9-CBDXziRtcLpYAnyLfjmoliSz6hr3X2Hig0QGTqnC8b9KJqUiXcHq093nMK7ftFS0g/exec";
    const string RankUpdataURLs = "https://docs.google.com/spreadsheets/d/1s1jZriYn_WqKTBZuX0WRbfFLnMmHFpwG2c7HMPtrDLo/export?format=tsv&range=A2:F&gid=0";
    [SerializeField] int testScore;

    public void GameOver(int _Score)
    {
        testScore = _Score;


        var testString = testScore.ToString();

        WWWForm form = new WWWForm();
        form.AddField("order", "AddRank");
        form.AddField("PlayerName","MainManager.Instance.PlayerName");
        form.AddField("Score", testString);

        StartCoroutine(RankUpData(form));
    }

    public IEnumerator RankUpData(WWWForm _form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(RankURL, _form))
        {
            yield return www.SendWebRequest();    
        }
        UnityWebRequest www2 = UnityWebRequest.Get(RankUpdataURLs);
        yield return www2.SendWebRequest();
        string[] row = www2.downloadHandler.text.Split('\n');
        int rowsize = row.Length;
         var PlayersData = new List<PlayerInformation>();

        for (int i = 0; i < rowsize; i++)
        {
            string[] column = row[i].Split('\t');
            PlayersData.Add(new PlayerInformation(System.Convert.ToInt32(column[0]),column[1]));
        }

        var RankList = PlayersData.OrderByDescending(player => player.Score).ToList();
        var list = new List<PlayerInformation>();
        for (var i = 0; i < 5; i++)
            list.Add(RankList[i]);
        var nameList = new List<string>();
        
        UIManager.Instance.RankUI.GetComponent<RankUI>().Init(list);
    }

    public IEnumerator StartPlayGame()
    {
        UnityWebRequest www2 = UnityWebRequest.Get(RankUpdataURLs);
        yield return www2.SendWebRequest();
        string[] row = www2.downloadHandler.text.Split('\n');
        int rowsize = row.Length;
         var PlayersData = new List<PlayerInformation>();

        for (int i = 0; i < rowsize; i++)
        {
            string[] column = row[i].Split('\t');
            PlayersData.Add(new PlayerInformation(System.Convert.ToInt32(column[0]),column[1]));
        }

        var RankList = PlayersData.OrderByDescending(player => player.Score).ToList();
        var list = new List<PlayerInformation>();
        for (var i = 0; i < 5; i++)
            list.Add(RankList[i]);
        var nameList = new List<string>();
        
        UIManager.Instance.RankUI.GetComponent<RankUI>().Init(list);
    }
}
