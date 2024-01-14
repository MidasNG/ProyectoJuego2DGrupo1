using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "Score = " + score.ToString(); 
    }

    
    public void AddPoint()
    {
        score += Random.Range(25, 50);
        scoreText.text = "Score = " + score.ToString();
    }
}
