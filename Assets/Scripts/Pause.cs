using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseTruck : MonoBehaviour
{
    private bool pause = false;
    private GameObject continuar, salir, texto;
    private float contador = 1f;

    void Start()
    {
        Time.timeScale = 1f;
        continuar = transform.GetChild(0).gameObject;
        salir = transform.GetChild(1).gameObject;
        texto = transform.GetChild(2).gameObject;
        continuar.SetActive(false);
        salir.SetActive(false);
        texto.SetActive(false);
    }

    void Update()
    {
        contador -= Time.deltaTime;

        if (contador <= 0)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                pause = !pause;
                if (pause)
                {
                    continuar.SetActive(true);
                    salir.SetActive(true);
                    texto.SetActive(true);
                    Time.timeScale = 0;

                }
                else
                {
                    continuar.SetActive(false);
                    salir.SetActive(false);
                    texto.SetActive(false);
                    Time.timeScale = 1;
                }


            }
        }
       
    }

    public void Salir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu minijuegos");
    }

    public void Continuar()
    {
        pause = !pause;
        if (pause)
        {
            continuar.SetActive(true);
            salir.SetActive(true);
            texto.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            continuar.SetActive(false);
            salir.SetActive(false);
            texto.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
