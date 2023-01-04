using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngrenageScore : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        score = PlayerPrefs.GetInt("Engrenage", score);
         
        AffichageScore();
    }

    public void GetEngrenage()
    {
        score = PlayerPrefs.GetInt("Engrenage") + 1;
        PlayerPrefs.SetInt("Engrenage", score);
        AffichageScore(); 
    }

    private void AffichageScore()
    {
        GetComponent<Text>().text = score.ToString() + "/5";
    }

    void Update()
    {
        
    }
}
