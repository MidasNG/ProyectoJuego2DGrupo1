using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool pause = false;
    private GameObject continuar, salir, texto;

    void Start()
    {
        continuar = transform.GetChild(0).gameObject;
        salir = transform.GetChild(1).gameObject;
        texto = transform.GetChild(2).gameObject;
        continuar.SetActive(false);
        salir.SetActive(false);
        texto.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }

        //Los ifs son para el minijuego truck
        if (pause && Time.timeScale == 1)
        {
            continuar.SetActive(true);
            salir.SetActive(true);
            texto.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            continuar.SetActive(false);
            salir.SetActive(false);
            texto.SetActive(false);
            Time.timeScale = 1;           
        }
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu minijuegos");
    }

    public void Continuar()
    {
        pause = !pause;
    }
}
