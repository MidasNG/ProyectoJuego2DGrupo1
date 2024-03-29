using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveHeartGreen : MonoBehaviour
{
    [SerializeField] private float inicialSpeed;
    private bool dentro = false;
    private int contador = 0;
    private float interact;
    private float otherInteract;
    private float actualSpeed;

    private void Start()
    {
        actualSpeed = inicialSpeed;
    }
    void Update()
    {
        transform.position += transform.right * actualSpeed * Time.deltaTime;
       

        interact = Input.GetAxisRaw("Interact");
        otherInteract = Input.GetAxisRaw("InteractGame");
        

        if (contador == 2)
        {
            dentro = true;
        }else
        {
            dentro = false;
        }
        if (Time.timeScale == 1)
        {
            if (otherInteract > 0)
            {
                if (dentro == true)
                {
                    ScoreManager.instance.RemovePointRhythm();
                    Destroy(gameObject);
                }
            }
            if (interact > 0)
            {
                if (dentro == true)
                {
                    ScoreManager.instance.AddPointRhythm();
                    Destroy(gameObject);
                }
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RhythmHeart")
        {
            contador++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RhythmHeart")
        {
            contador--;
        }

        if (collision.gameObject.tag == "RhythmDestroyer")
        {
            ScoreManager.instance.RemovePointRhythm2();
            Destroy(gameObject);
        }

    }

}
