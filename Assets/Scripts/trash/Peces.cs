using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peces : MonoBehaviour
{
    private AudioSource clipPez;
    private SpriteRenderer render;
    private CapsuleCollider2D colisionador;

    void Start()
    {
        clipPez = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clipPez.Play();
            render.enabled = false;
            colisionador.enabled = false;

            Destroy(gameObject, 2);
        }
    }
}
