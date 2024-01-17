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

    int scoreRhythm = 0;
    int scoreApagon = 0;
    int scoreTruck = 0;
    int scoreTrash = 0;
    int scoreFeed = 0;

    float contadorApagon = 15f;
    int comboTruck = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
        scoreTextApagon.text = "Puntos: " + scoreApagon.ToString();
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
        scoreTextTrash.text = "Puntos: " + scoreTrash.ToString();
        scoreTextFeed.text = "Puntos: " + scoreFeed.ToString();

    }

    private void Update()
    {
        contadorApagon -= Time.deltaTime;
    }


    public void AddPointRhythm()
    {
        scoreRhythm += Random.Range(10, 20);
        scoreTextRhythm.text = "Puntos: " + scoreRhythm.ToString();
    }

    public void RemovePointRhythm()
    {
        scoreRhythm -= Random.Range(10, 20);
        scoreTextRhythm.text = "Puntos; " + scoreRhythm.ToString();
    }

    public void RemovePointRhythm2()
    {
        scoreRhythm -= Random.Range(5, 15);
        scoreTextRhythm.text = "Puntos; " + scoreRhythm.ToString();
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
    }

    public void AddPointTruck()
    {
        comboTruck++;
        scoreTruck += 15 + comboTruck;
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
    }

    public void RemovePointTruck()
    {
        comboTruck = 0;
        scoreTruck -= 20;
        scoreTextTruck.text = "Puntos: " + scoreTruck.ToString();
    }
}
