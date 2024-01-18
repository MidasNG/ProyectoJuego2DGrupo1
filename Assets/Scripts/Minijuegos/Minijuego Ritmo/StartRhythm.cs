using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class StartRhythm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoCuentaAtras;
    [SerializeField] private float duracionCuentaAtras;


    private void Start()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(CuentaAtras());
    }

    IEnumerator CuentaAtras()
    {
        float tiempoRestante = duracionCuentaAtras;

        while (tiempoRestante > 0f)
        {

            textoCuentaAtras.text = tiempoRestante.ToString("F0");

            yield return new WaitForSecondsRealtime(1f);

            tiempoRestante--;
        }

        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }

}
