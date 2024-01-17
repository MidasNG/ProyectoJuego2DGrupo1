using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerApagón : MonoBehaviour
{
    public float timer = 15;
    private TextMeshProUGUI textoTimer;


    void Start()
    {
        textoTimer = GetComponent<TextMeshProUGUI>();
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
            SceneManager.LoadSceneAsync("Menu minijuegos");

        }

       
    }
}
