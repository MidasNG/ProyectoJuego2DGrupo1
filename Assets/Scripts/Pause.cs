using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool pause = false;
    private GameObject continuar, salir;

    void Start()
    {
        continuar = transform.GetChild(0).gameObject;
        salir = transform.GetChild(1).gameObject;
        continuar.SetActive(false);
        salir.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }

        if (pause)
        {
            continuar.SetActive(true);
            salir.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            continuar.SetActive(false);
            salir.SetActive(false);
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
