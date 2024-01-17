using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApagonEncender : MonoBehaviour
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

    private void Start()
    {
        dark.SetActive(true);
        dark2.SetActive(false);

        verde.SetActive(false);
        verdefondo.SetActive(false);

        night.SetActive(false);

        audiopalanca = GetComponent<AudioSource>();

        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

            // No necesitas destruir el collider si vas a cambiar de escena

            StartCoroutine(CambioNivel());
        }
    }

    private IEnumerator CambioNivel()
    {
        yield return new WaitForSeconds(3f);

        // Cambia la siguiente línea para cargar la siguiente escena en GameManager
        GameManager.instance.StartCoroutine(GameManager.instance.StartNextMinigame());
    }
}
