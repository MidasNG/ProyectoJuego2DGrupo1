using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerApagón : MonoBehaviour
{
    public float timer = 15;
    private TextMeshProUGUI textoTimer;
    private AudioSource loser;


    void Start()
    {
        textoTimer = GetComponent<TextMeshProUGUI>();
        loser = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            textoTimer.text = "Tiempo: " + timer.ToString("f0");
        }
        else if (timer < 1)
        {
            StartCoroutine(gameover());
           
        }

    }

    public IEnumerator gameover()
    {
        loser.Play();

        yield return new WaitForSeconds(3f);

        SceneManager.LoadSceneAsync("Menu minijuegos");

    }
}

