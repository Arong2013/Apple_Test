using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankSlot : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI _score,_name;
   public  void AddRank(Sprite icon,int Score,string name)
    {
        if(icon)
            _icon.sprite= icon; 
            else
            {
                Destroy(_icon);
            }
        _score.text = Score.ToString();    
        _name.text = name.ToString();  
    }
}
