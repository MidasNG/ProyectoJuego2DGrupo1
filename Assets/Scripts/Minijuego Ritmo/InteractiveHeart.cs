using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveHeart : MonoBehaviour
{
    public float inicialSpeed;
    private bool dentro = false;
    private int contador = 0;
    private float interact;
    private static float actualSpeed;
    private float progressiveSpeed = 5f;

    private void Start()
    {
        actualSpeed = inicialSpeed;
    }
    void Update()
    {
        transform.position += transform.right * actualSpeed * Time.deltaTime;
        actualSpeed += progressiveSpeed * Time.deltaTime;
       

        interact = Input.GetAxisRaw("InteractGame");
        

        if (contador == 2)
        {
            dentro = true;
        }else
        {
            dentro = false;
        }

        if (interact > 0)
        {
            if (dentro == true)
            {
                ScoreManager.instance.AddPoint();
                Destroy(gameObject);
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
            Destroy(gameObject);
        }

    }

}
