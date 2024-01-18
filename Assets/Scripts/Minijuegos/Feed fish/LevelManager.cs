using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nombreDeLaSiguienteEscena = "NombreDeTuSiguienteEscena"; // Reemplaza con el nombre de tu siguiente escena
    public float tiempoAntesDeCambiarEscena = 20.0f; // Tiempo antes de cambiar a la siguiente escena
    public float tiempoEsperaDespuesDeMusica = 5.0f; // Tiempo de espera después de la música antes de cambiar la escena
    public AudioSource audioSourceOriginal; // Asigna el componente AudioSource de la música original desde el Inspector
    public AudioSource audioSourceVictoria; // Asigna el componente AudioSource de la música de victoria desde el Inspector
    public GameObject animObject; // Arrastra el objeto que contiene el Animator desde el Inspector

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
