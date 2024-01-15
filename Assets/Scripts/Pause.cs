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
            if (pause)
            {
                continuar.SetActive(true);
                salir.SetActive(true);
                texto.SetActive(true);
                Time.timeScale = 0;
                print("flipA");
            }
            else
            {
                continuar.SetActive(false);
                salir.SetActive(false);
                texto.SetActive(false);
                Time.timeScale = 1;
                print("flipB");
            }

        
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
