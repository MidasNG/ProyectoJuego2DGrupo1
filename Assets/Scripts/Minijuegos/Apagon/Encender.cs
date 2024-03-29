﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Encender : MonoBehaviour
{

    [SerializeField] private GameObject dark;
    [SerializeField] private GameObject dark2;
    [SerializeField] private GameObject verde;
    [SerializeField] private GameObject verdefondo;
    [SerializeField] private Animator palanca;
    [SerializeField] private Animator lightup;
    [SerializeField] private GameObject night;
    private AudioSource audiopalanca;
    [SerializeField] private AudioSource audiovictory;
    [SerializeField] private AudioSource audiovictory2;
    [SerializeField] private AudioSource soundtrack;
    private BoxCollider2D box;
    private int lvl;
    [SerializeField] private GameObject lvl1;
    [SerializeField] private GameObject lvl3;
    [SerializeField] private GameObject lvl2;
    [SerializeField] private GameObject lvl4;
    [SerializeField] private Playercontroller scriptplayer;

    // Start is called before the first frame update
    void Start()
    {
        dark.SetActive(true);
        dark2.SetActive(false);

        verde.SetActive(false);
        verdefondo.SetActive(false);

        night.SetActive(false);

        audiopalanca=GetComponent<AudioSource>();

        box = GetComponent<BoxCollider2D>();

        lvl = Random.Range(1,5);

        StartCoroutine(bloqueo());


        if (lvl == 1)
        {
            lvl1.SetActive(true);
            transform.position = new Vector2(-0.3f,2.64f);
        }

        else if (lvl == 2)
        {
            lvl2.SetActive(true);
            transform.position = new Vector2(15.23f, 2.64f);
        }

        else if (lvl == 3)
        {
            lvl3.SetActive(true);
            transform.position = new Vector2(5.71f, 5.84f);
        }

        else if (lvl == 4)
        {
            lvl4.SetActive(true);
            transform.position = new Vector2(7.73f, 5.75f);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dark.SetActive(false);
            dark2.SetActive(true);

            verde.SetActive(true);
            verdefondo.SetActive(true);

            night.SetActive(true);
            palanca.SetTrigger("activar");
            lightup.SetTrigger("encender");

            audiopalanca.Play();
            audiovictory.Play();
            audiovictory2.Play();
            soundtrack.volume = 0.08f;

            ScoreManager.instance.AddPointApagon();

            Destroy(box);

            StartCoroutine(cambiolvl());

          
        }
       

    }

    public IEnumerator cambiolvl()
    {
            yield return new WaitForSeconds(3f);

            SceneManager.LoadSceneAsync("Menu minijuegos");

    }

    public IEnumerator bloqueo()
    {
        scriptplayer.enabled = false;

        yield return new WaitForSeconds(3f);

        scriptplayer.enabled = true;
    }
}
