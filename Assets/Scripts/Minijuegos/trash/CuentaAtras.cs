using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{
    public Text countdownText;
    public float countdownTime = 30f; // Tiempo inicial para la cuenta atr�s

    void Start()
    {
        // Comienza la cuenta atr�s cuando el script se inicializa
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            // Actualiza el texto con el valor actual de la cuenta atr�s
            countdownText.text = countdownTime.ToString("0");

            // Espera un segundo
            yield return new WaitForSeconds(1f);

            // Reduce el tiempo en 1 segundo
            countdownTime--;
        }

        // Cuando la cuenta atr�s llega a 0, cambia a la siguiente escena
        ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Menu minijuegos");
    }
}