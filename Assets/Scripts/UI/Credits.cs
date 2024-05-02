using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Credits : MonoBehaviour
{
     public float duration = 30.0f; // 애니메이션 지속 시간
    public float angle = 30.0f;    // 텍스트 기울기 각도

    [SerializeField] TextMeshProUGUI textMeshProUGUI;


    Vector3 startPos;
    private void OnEnable() 
    {
        startPos = textMeshProUGUI.transform.position;

        textMeshProUGUI.transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));

        Vector3 endPosition = textMeshProUGUI.transform.position + new Vector3(0, 100, 0); // 100은 원하는 높이에 따라 조정 가능
        textMeshProUGUI.transform.DOMove(endPosition, duration).SetEase(Ease.Linear);
    }

    private void OnDisable() 
    {
        textMeshProUGUI.transform.position = startPos;
    }
}
