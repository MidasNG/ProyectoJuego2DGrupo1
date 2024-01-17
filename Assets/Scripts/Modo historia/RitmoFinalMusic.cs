using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitmoFinalMusic : MonoBehaviour
{
    private AudioSource finalMusic;

    void Start()
    {
        // Inicia la reproducción de la música de ritmo
        StartCoroutine(IniciarRitmo());
    }

    IEnumerator IniciarRitmo()
    {
        finalMusic = GetComponent<AudioSource>();
        finalMusic.Pause();

        // Espera 20 segundos antes de comenzar la música
        yield return new WaitForSeconds(20f);

        finalMusic.Play();

        // Espera 5 segundos antes de cambiar de escena
        yield return new WaitForSeconds(5f);

        // Cambia la siguiente línea para cargar la siguiente escena en GameManager
        GameManager.instance.StartCoroutine(GameManager.instance.StartNextMinigame());
    }
}
