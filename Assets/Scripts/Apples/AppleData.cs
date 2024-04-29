using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AppleData", menuName = "AppleData", order = 1)]
public class AppleData : ScriptableObject
{
<<<<<<< HEAD
   [SerializeField] string appleName; public string AppleName => appleName;
    [SerializeField] int score; public int Score => score;
=======
     [SerializeField]   string appleName; public string AppleName => appleName;
    [SerializeField] int score; public int Score => score;

>>>>>>> main
    [SerializeField] GameObject nextApple; public GameObject NextApple => nextApple;
}
