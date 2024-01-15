using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            ScoreManagerApagón.instance.AddPoint();

            Destroy(box);

            StartCoroutine(cambiolvl());

        }
       

    }

    public IEnumerator cambiolvl()
    {
            yield return new WaitForSeconds(5f);

            SceneManager.LoadSceneAsync("Menu minijuegos");

    }
}
