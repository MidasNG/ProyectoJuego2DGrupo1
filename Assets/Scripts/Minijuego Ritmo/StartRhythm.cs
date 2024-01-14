using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class StartRhythm : MonoBehaviour
{
    public TextMeshProUGUI textoCuentaAtras;
    public float duracionCuentaAtras = 3f;


    private void Start()
    {
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

        Destroy(gameObject);
    }



    //IEnumerator Start()
    //{
    //    Time.timeScale = 0;

    //    yield return new WaitForSecondsRealtime(3f);

    //    Time.timeScale = 1;
    //}
}
