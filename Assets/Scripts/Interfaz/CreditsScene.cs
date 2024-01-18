using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedFishLevelManager : MonoBehaviour
{
    public float tiempoEspera = 5f; // Tiempo de espera en segundos
    public string nombreDeLaSiguienteEscena; // Nombre de la siguiente escena

    private void Start()
    {
        // Invocar el método para cambiar de escena después del tiempo de espera
        Invoke("CambiarDeEscena", tiempoEspera);
    }

    private void CambiarDeEscena()
    {
        if (!string.IsNullOrEmpty(nombreDeLaSiguienteEscena))
        {
            SceneManager.LoadScene(nombreDeLaSiguienteEscena);
        }
        else
        {
            Debug.LogWarning("Nombre de la siguiente escena no especificado en el inspector.");
        }
    }
}