using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerApagón : MonoBehaviour
{
    [SerializeField] private float timer;
    private TextMeshProUGUI textoTimer;
    private AudioSource loser;
    private bool gameover=false;
    [SerializeField] private AudioSource soundtrack;

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
        else if (timer < 1 && !gameover)
        {
            StartCoroutine(GameOver());
            gameover = true;
           
        }

    }

    public IEnumerator GameOver()
    {
        Destroy(soundtrack);

        loser.Play();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadSceneAsync("Menu minijuegos");

    }
}

