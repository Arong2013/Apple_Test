using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetBestScore : MonoBehaviour
{
    public TextMeshProUGUI Mytext;
    //public RankSystem Best_Score;
    List<PlayerInformation> rank;


    public void Init(List<PlayerInformation> _list)
    {
        rank = _list;
        Mytext.text = rank[0].Score.ToString();
    }
    

}
