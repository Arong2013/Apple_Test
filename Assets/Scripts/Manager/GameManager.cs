using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] SerializedDictionary<int, GameObject> NextAppleData;
    RankSystem rankSystem;
    [SerializeField] Transform AppleDropTransform;

   
    [SerializeField] int score = 0; public int Score => score;
    [SerializeField] int Fever_count = 0; public int Fever => Fever_count;
    private AppleObj cunObj; public AppleObj CunObj => cunObj;
   

    public void Start()
    {
        rankSystem = GetComponent<RankSystem>();    

       // GameObject apple = Instantiate(NextApple().gameObject, AppleDropTransform.transform.position, Quaternion.identity);
       // cunObj = apple.GetComponent<AppleObj>();
    }
    /*
    public void Update()
    {
        if(!cunObj.IsMoveable || !cunObj)
        {
            GameObject apple =  Instantiate(NextApple().gameObject, AppleDropTransform.transform.position, Quaternion.identity);
            cunObj = apple.GetComponent<AppleObj>();
            score += cunObj.AppleData.Score;
        }    
    }
   */
    /// <summary>
    /// ���� ���� �÷��ְ� ���� 
    /// </summary>
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
   
    public void AddAppleScore(int _score)
    {
        score += _score;
    }

    public void AddFeverCount(int _fever)
    {
        Fever_count += _fever;
        Debug.Log("Check");
    }

    public void FeverInitialize()
    {
        Fever_count =0;
    }
    public void GameOver()
    {
        rankSystem.GameOver(score);
    }
}
