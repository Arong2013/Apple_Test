using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankSystem : MonoBehaviour
{
    const string RankURL = "https://script.google.com/macros/s/AKfycbwrPsz6Iq07whi9aZvTn4Cq012hN3So2C1fIyH2nEZBzGcFmR6DlNlPhqQajDWUjItO2A/exec";
    const string RankUpdataURLs = "https://docs.google.com/spreadsheets/d/1s1jZriYn_WqKTBZuX0WRbfFLnMmHFpwG2c7HMPtrDLo/export?format=tsv&range=A2:F&gid=0";
    [SerializeField] List<int> Ranks = new List<int>();

    [SerializeField] int testScore;
    public void Start()
    {
        var testString = testScore.ToString(); 

        WWWForm form = new WWWForm();
        form.AddField("order", "AddRank");
        form.AddField("Score", testString);

        StartCoroutine(RankUpData(form));
    }

    public IEnumerator RankUpData(WWWForm _form)
    {

        using (UnityWebRequest www = UnityWebRequest.Post(RankURL, _form))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
                print(www.downloadHandler.text);

            
          
        }

        UnityWebRequest www2 = UnityWebRequest.Get(RankUpdataURLs);
        yield return www2.SendWebRequest();
        string[] row = www2.downloadHandler.text.Split('\n');
        int rowsize = row.Length;

        for (int i = 0; i < rowsize; i++)
        {
            string[] column = row[i].Split('\t');
            Ranks.Add(System.Convert.ToInt32(column[0]));
        }
        Ranks.Sort();
    }
}
