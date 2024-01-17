using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedFishLevelManager : MonoBehaviour
{
    public float tiempoAntesDeCambiarEscena = 20.0f; // Tiempo antes de cambiar a la siguiente escena

    void Start()
    {
        // Inicia el temporizador para cambiar de escena
        StartCoroutine(CambiarEscenaDespuesDeTiempo());
    }

    IEnumerator CambiarEscenaDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoAntesDeCambiarEscena);

        // Cambia la siguiente línea para cargar la siguiente escena en GameManager
        GameManager.instance.StartCoroutine(GameManager.instance.StartNextMinigame());
    }
}