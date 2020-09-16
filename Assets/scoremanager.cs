using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    public static scoremanager Instance;
    public int score;
    void Awake()
    {
        Instance = this;
    }

    public void ScoreUpdate(int ammount)
    {
        score += ammount;
        if (score > PlayerPrefs.GetInt("BestScore", 0))
        PlayerPrefs.SetInt("BestScore", score);
    }
    
}
