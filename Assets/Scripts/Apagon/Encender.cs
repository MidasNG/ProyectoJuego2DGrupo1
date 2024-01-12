using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encender : MonoBehaviour
{

    public GameObject dark;
    public GameObject dark2;
    public GameObject nuclear;
    public GameObject verde;
    public Animator palanca;
    public Animator lightup;
    public GameObject night;




    // Start is called before the first frame update
    void Start()
    {
        dark.SetActive(true);
        nuclear.SetActive(true);
        dark2.SetActive(false);
        verde.SetActive(false);
        night.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dark.SetActive(false);
            nuclear.SetActive(false);
            dark2.SetActive(true);
            verde.SetActive(true);
            night.SetActive(true);
            palanca.SetTrigger("activar");
            lightup.SetTrigger("encender");
        }
    }
}
