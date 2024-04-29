using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class RankUI : MonoBehaviour
{
    [SerializeField] Transform Parent;
    List<RankSlot> slotList = new List<RankSlot>();

    [SerializeField] Sprite GoldMd,SilverMd,BronzeMd;
    List<PlayerInformation> rank;
    public void OnEnable()
    {
        
    }

    private void Start() {
        
    }
    public void Init(List<PlayerInformation> _list)
    {
        rank = _list;


        for(var a = 0; a < Parent.childCount; a++)
        {
            slotList.Add(Parent.GetChild(a).GetComponent<RankSlot>());
        }

        for(int i = 0; i<rank.Count; i++)
        {
            if (i == 0)
                slotList[i].AddRank(GoldMd, rank[i].Score, rank[i].playerName);
            else if (i == 1)
                slotList[i].AddRank(SilverMd, rank[i].Score, rank[i].playerName);
            else if (i == 2)
                slotList[i].AddRank(BronzeMd, rank[i].Score, rank[i].playerName);
            else
                slotList[i].AddRank(null, rank[i].Score, rank[i].playerName);
        }
    }
}
