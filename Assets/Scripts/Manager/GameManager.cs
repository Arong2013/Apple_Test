using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] SerializedDictionary<int, GameObject> NextAppleData;
    [SerializeField] Transform AppleDropTransform;

   
    int score = 0; public int Score => score;
    private AppleObj cunObj; public AppleObj CunObj => cunObj;

    public void Start()
    {
        GameObject apple = Instantiate(NextApple().gameObject, AppleDropTransform.transform.position, Quaternion.identity);
        cunObj = apple.GetComponent<AppleObj>();
    }

    public void Update()
    {
        if(!cunObj.IsMoveable || !cunObj)
        {
            GameObject apple =  Instantiate(NextApple().gameObject, AppleDropTransform.transform.position, Quaternion.identity);
            cunObj = apple.GetComponent<AppleObj>();
            score += cunObj.AppleData.Score;
        }    
    }


    public void AddScore(AppleObj _apple, Vector3 _pos)
    {
        score += _apple.AppleData.Score;
        if (_apple.AppleData.NextApple)
            Instantiate(_apple.AppleData.NextApple.gameObject, _pos, Quaternion.identity);
    }

    public GameObject NextApple()
    {
        var randcount = Random.Range(0, 101);
        var apple = NextAppleData.Keys.First(x => x >= randcount);
        return NextAppleData[apple];
    }
}
