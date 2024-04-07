using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class RankUI : MonoBehaviour
{
    [SerializeField] Transform Parent;
    [SerializeField] RankSlot Slot;

    [SerializeField] Sprite GoldMd,SilverMd,BronzeMd;
    List<int> rank;
    public void OnEnable()
    {
        for(int i = 0; i<rank.Count; i++)
        {
            RankSlot slot = Instantiate(Slot.gameObject, Parent).GetComponent<RankSlot>();
            if (i == 0)
                slot.AddRank(GoldMd, rank[i], "Dong");
            else if (i == 1)
                slot.AddRank(SilverMd, rank[i], "Dong");
            else if (i == 2)
                slot.AddRank(BronzeMd, rank[i], "Dong");
            else
                slot.AddRank(null, rank[i], "Dong");
        }
    }

    public void Init(List<int > rankList)
    {
        rank = rankList;
        gameObject.SetActive(true); 
    }
}
