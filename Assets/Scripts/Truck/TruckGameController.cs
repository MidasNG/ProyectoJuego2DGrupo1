using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckGameController : MonoBehaviour
{
    private float time = 0f, finishTime = 10f;
    private int score = 0;

    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time > finishTime)
        {

        }
    }

    public void AddScore()
    {
        score++;
    }

    public void SubtractScore()
    {
        score--;
    }
}
