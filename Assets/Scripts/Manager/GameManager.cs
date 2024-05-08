using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] SerializedDictionary<int, GameObject> NextAppleData;
    public RankSystem rankSystem;
    [SerializeField] Transform AppleDropTransform;


    [SerializeField] int score = 0; public int Score => score;
    [SerializeField] int Fever_count = 0; public int Fever => Fever_count;
    private AppleObj cunObj; public AppleObj CunObj => cunObj;


    public void Start()
    {
        rankSystem = GetComponent<RankSystem>();
        StartRank();
         SceneManager.sceneLoaded += OnSceneLoaded;
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
    ///AddScore함수입니다
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
    }

    public void FeverInitialize()
    {
        Fever_count = 0;
    }
    public void GameOver()
    {
        UIManager.Instance.GameOverUI.SetActive(true);
        rankSystem.GameOver(score);
    }

    public void Restart()
    {
        Destroy(UIManager.Instance.gameObject);
        SceneManager.LoadScene("Pixel_Modifying_Play_Scene");
        Time.timeScale = 1;
    }

     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         StartCoroutine(rankSystem.StartPlayGame());  
         Fever_count = 0;
         score = 0;
    }

    private void OnDisable() {
        
        print("지워짐");
    }


    public void StartRank()
    {
        StartCoroutine(rankSystem.StartPlayGame());  
    }

}
