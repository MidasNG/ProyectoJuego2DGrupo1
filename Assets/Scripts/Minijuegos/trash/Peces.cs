using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peces : MonoBehaviour
{
    public AudioSource clipPez;
    private SpriteRenderer render;
    private BoxCollider2D colisionador;

    void Start()
    {
        clipPez = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.RemovePointTrash();

            clipPez.Play();
            render.enabled = false;
            colisionador.enabled = false;

            Destroy(gameObject, 2);
        }
    }
}
