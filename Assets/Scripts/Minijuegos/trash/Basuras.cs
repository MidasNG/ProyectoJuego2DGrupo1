using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basuras : MonoBehaviour
{
    private AudioSource clip;
    private SpriteRenderer render;
    private CircleCollider2D colisionador;
    public AudioSource win;

    public static int score = 0;

    void Start()
    {
        clip = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (score == 10) 
        { 
            win.Play();
            StartCoroutine(FinishGame());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddPointTrash();
            score++;
            clip.Play();
            render.enabled = false;
            colisionador.enabled = false;

            Destroy(gameObject, 6);
        }
    }

    IEnumerator FinishGame()
    {
        win = GetComponent<AudioSource>();
        win.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu minijuegos");
    }
}
