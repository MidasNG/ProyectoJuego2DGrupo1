using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basuras : MonoBehaviour
{
    private AudioSource clip;
    private SpriteRenderer render;
    private CircleCollider2D colisionador;

    void Start()
    {
        clip = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScriptContador.instance.CogerBasuras();

            clip.Play();
            render.enabled = false;
            colisionador.enabled = false;

            Destroy(gameObject, 2);
        }
    }
}
