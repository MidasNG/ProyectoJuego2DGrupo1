using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerApagón : MonoBehaviour
{
    public static ScoreManagerApagón instance;
    public TextMeshProUGUI scoreText;
    private float contador = 16f; 

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "Puntos: " + score.ToString();
    }

    private void Update()
    {
        contador -= Time.deltaTime;
    }


    public void AddPoint()
    {
        if (contador >= 10 && contador < 16)
        {
            score = 100;
            scoreText.text = "Puntos: " + score.ToString();
        }

        if (contador >= 5 && contador < 10)
        {
            score = 75;
            scoreText.text = "Puntos: " + score.ToString();
        }

        if (contador >= 0 && contador < 5)
        {
            score = 50;
            scoreText.text = "Puntos: " + score.ToString();
        }
    }
}
