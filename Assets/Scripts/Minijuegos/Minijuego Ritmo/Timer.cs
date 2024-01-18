using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
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
        } else if (timer == 0)
        {
            textoTimer.text = "Tiempo: " + timer.ToString("f0");
        }

        
    }
}
