using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Encender : MonoBehaviour
{

    public GameObject dark;
    public GameObject dark2;
    public GameObject verde;
    public GameObject verdefondo;
    public Animator palanca;
    public Animator lightup;
    public GameObject night;
    private AudioSource audiopalanca;
    public AudioSource audiovictory;
    public AudioSource audiovictory2;
    public AudioSource soundtrack;
    private BoxCollider2D box;
    private int lvl;
    public GameObject lvl1;
    public GameObject lvl3;
    public GameObject lvl2;
    public GameObject lvl4;

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
            transform.position = new Vector2(-0.3f,5.8f);
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
}
