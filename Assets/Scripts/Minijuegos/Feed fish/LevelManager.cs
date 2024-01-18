using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nombreDeLaSiguienteEscena; // Reemplaza con el nombre de tu siguiente escena
    [SerializeField] private float tiempoAntesDeCambiarEscena; // Tiempo antes de cambiar a la siguiente escena
    [SerializeField] private float tiempoEsperaDespuesDeMusica; // Tiempo de espera después de la música antes de cambiar la escena
    [SerializeField] private AudioSource audioSourceOriginal; // Asigna el componente AudioSource de la música original desde el Inspector
    [SerializeField] private AudioSource audioSourceVictoria; // Asigna el componente AudioSource de la música de victoria desde el Inspector
    [SerializeField] private GameObject animObject; // Arrastra el objeto que contiene el Animator desde el Inspector

    void Start()
    {
        // Inicia el temporizador para cambiar de escena
        StartCoroutine(CambiarEscenaDespuesDeTiempo());
    }

    IEnumerator CambiarEscenaDespuesDeTiempo()
    {
        // Reproducir música al iniciar la escena
        if (audioSourceOriginal != null)
        {
            audioSourceOriginal.Play();
        }

        yield return new WaitForSeconds(tiempoAntesDeCambiarEscena);

        // Detener la música original después de 20 segundos
        if (audioSourceOriginal != null)
        {
            audioSourceOriginal.Stop();
        }

        // Reproducir la música de victoria
        if (audioSourceVictoria != null)
        {
            audioSourceVictoria.Play();
        }

        // Congelar el juego durante 5 segundos
        Time.timeScale = 0f;
        float endTime = Time.realtimeSinceStartup + tiempoEsperaDespuesDeMusica;

        // Reproducir la animación
        if (animObject != null)
        {
            Animator anim = animObject.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("PlayAnimation"); // "PlayAnimation" es el nombre del trigger en el Animator
            }
        }

        while (Time.realtimeSinceStartup < endTime)
        {
            yield return null; // Esperar hasta que el tiempo haya pasado
        }

        // Restaurar la escala de tiempo
        Time.timeScale = 1f;

        // Cambiar a la siguiente escena
        SceneManager.LoadScene(nombreDeLaSiguienteEscena);
    }
}
