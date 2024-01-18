using System.Collections;
using UnityEngine;

public class AutoSpeedController : MonoBehaviour
{
    [SerializeField] private float intervaloAceleracion; // Intervalo de tiempo entre aceleraciones
    [SerializeField] private float factorAceleracion; // Factor de aceleraci�n

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
