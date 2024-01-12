using System.Collections;
using UnityEngine;

public class AutoSpeedController : MonoBehaviour
{
    public float intervaloAceleracion = 10.0f; // Intervalo de tiempo entre aceleraciones
    public float factorAceleracion = 2.0f; // Factor de aceleraci�n

    private void Start()
    {
        // Comenzar el bucle de aceleraci�n en segundo plano
        StartCoroutine(AutoAcelerarJuego());
    }

    IEnumerator AutoAcelerarJuego()
    {
        while (true)
        {
            // Acelerar el juego
            Time.timeScale = factorAceleracion;

            // Esperar el intervalo de aceleraci�n
            yield return new WaitForSeconds(intervaloAceleracion);

            // Restablecer la escala del tiempo a 1.0
            Time.timeScale = 1.0f;
        }
    }
}
