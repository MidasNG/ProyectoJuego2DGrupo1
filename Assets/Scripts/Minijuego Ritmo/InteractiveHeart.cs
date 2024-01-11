using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveHeart : MonoBehaviour
{
    public float Speed;
    private bool dentro = false;
    public int contador = 0;
    private float interact;
    public TextMeshProUGUI texto;
    private int score = 0;

    void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        interact = Input.GetAxisRaw("InteractGame");
        transform.position += transform.right * Speed * Time.deltaTime;

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
                AddPoint();
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

    private int AddPoint()
    {
        score = +100;
        texto.text = "Score = " + score.ToString();
        return score;
    }

}
