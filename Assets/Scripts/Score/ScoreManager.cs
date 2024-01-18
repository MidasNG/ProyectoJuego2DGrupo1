using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreTextRhythm;
    public TextMeshProUGUI scoreTextApagon;
    public TextMeshProUGUI scoreTextTruck;
    public TextMeshProUGUI scoreTextTrash;
    public TextMeshProUGUI scoreTextFeed;

    public TextMeshProUGUI highscoreTextRhythm;
    public TextMeshProUGUI highscoreTextApagon;
    public TextMeshProUGUI highscoreTextTruck;
    public TextMeshProUGUI highscoreTextTrash;
    public TextMeshProUGUI highscoreTextFeed;

    int scoreRhythm = 0;
    int highscoreRhythm = 0;

    int scoreApagon = 0;
    int highscoreApagon = 0;

    int scoreTruck = 0;
    int highscoreTruck = 0;

    int scoreTrash = 0;
    int highscoreTrash = 0;

    int scoreFeed = 0;
    int highscoreFeed = 0;

    float contadorApagon = 15f;
    int comboTruck = 0;
    int comboRhythm = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscoreRhythm = PlayerPrefs.GetInt("highscoreRhythm", 0);
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
        highscoreTextRhythm.text = "High Score: " + highscoreRhythm.ToString();

        highscoreApagon = PlayerPrefs.GetInt("highscoreApagon", 0);
        scoreTextApagon.text = "Puntos: " + scoreApagon.ToString();
        highscoreTextApagon.text = "High Score: " + highscoreApagon.ToString();

        highscoreTruck = PlayerPrefs.GetInt("highscoreTruck", 0);
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
        highscoreTextTruck.text = "High Score: " + highscoreTruck.ToString();

        highscoreTrash = PlayerPrefs.GetInt("highscoreTrash", 0);
        scoreTextTrash.text = "Puntos: " + scoreTrash.ToString();
        highscoreTextTrash.text = "High Score: " + highscoreTrash.ToString();

        highscoreFeed = PlayerPrefs.GetInt("highscoreFeed", 0);
        scoreTextFeed.text = "Puntos: " + scoreFeed.ToString();
        highscoreTextFeed.text = "High Score: " + highscoreFeed.ToString();

    }

    private void Update()
    {
        contadorApagon -= Time.deltaTime;
    }


    public void AddPointRhythm()
    {
        comboRhythm++;
        scoreRhythm += 10 + comboRhythm;
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
        if (highscoreRhythm < scoreRhythm)
        {
            PlayerPrefs.SetInt("highscoreRhythm", scoreRhythm);
        }
    }

    public void RemovePointRhythm()
    {
        comboRhythm = 0;
        scoreRhythm -= 10;
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
    }

    public void RemovePointRhythm2()
    {
        comboRhythm = 0;
        scoreRhythm -= 5;
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
    }

    public void AddPointApagon()
    {
        if (contadorApagon >= 10 && contadorApagon < 16)
        {
            scoreApagon = 100;
            scoreTextApagon.text = "Puntos: " + scoreApagon.ToString();
        }

        if (contadorApagon >= 5 && contadorApagon < 10)
        {
            scoreApagon = 75;
            scoreTextApagon.text = "Puntos: " + scoreApagon.ToString();
        }

        if (contadorApagon >= 0 && contadorApagon < 5)
        {
            scoreApagon = 50;
            scoreTextApagon.text = "Puntos: " + scoreApagon.ToString();
        }

        if (highscoreApagon < scoreApagon)
        {
            PlayerPrefs.SetInt("highscoreApagon", scoreApagon);
        }

    }

    public void RemovePointTrash()
    {
        scoreTrash--;
        scoreTextTrash.text = "Puntos: " + scoreTrash.ToString();
    }

    public void AddPointTrash()
    {

        scoreTrash++;
        scoreTextTrash.text = "Puntos: " + scoreTrash.ToString();
        if (highscoreTrash < scoreTrash)
        {
            PlayerPrefs.SetInt("highscoreTrash", scoreTrash);
        }


        if (scoreTrash == 10)
        {
            StartCoroutine(EsperarYCambiarNivel());
        }


        IEnumerator EsperarYCambiarNivel()
        {

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene("Menu minijuegos");
        }

    }


    public void AddPointFeed()
    {
        scoreFeed += 5;
        scoreTextFeed.text = "Puntos: " + scoreFeed.ToString();

        if(highscoreFeed < scoreFeed)
        {
            PlayerPrefs.SetInt("highscoreFeed", scoreFeed);
        }
    }

    public void AddPointTruck()
    {
        comboTruck++;
        scoreTruck += 10 + comboTruck;
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
        if (highscoreTruck < scoreTruck)
        {
            PlayerPrefs.SetInt("highscoreTruck", scoreTruck);
        }

    }

    public void RemovePointTruck()
    {
        comboTruck = 0;
        scoreTruck -= 20;
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
    }

}
