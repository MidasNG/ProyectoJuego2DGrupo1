using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nombreDeLaSiguienteEscena = "NombreDeTuSiguienteEscena"; // Reemplaza con el nombre de tu siguiente escena
    public float tiempoAntesDeCambiarEscena = 20.0f; // Tiempo antes de cambiar a la siguiente escena

    void Start()
    {
        // Inicia el temporizador para cambiar de escena
        StartCoroutine(CambiarEscenaDespuesDeTiempo());
    }

    IEnumerator CambiarEscenaDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoAntesDeCambiarEscena);
        // Cambiar a la siguiente escena
        SceneManager.LoadScene(nombreDeLaSiguienteEscena);
    }
}
