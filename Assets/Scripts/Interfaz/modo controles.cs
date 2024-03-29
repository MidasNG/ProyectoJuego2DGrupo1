using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modocontroles : MonoBehaviour
{
    [SerializeField] private GameObject aviso;
    [SerializeField] private GameObject controles;
    [SerializeField] private GameObject cartel;
    [SerializeField] private GameObject teclado;
    [SerializeField] private GameObject mando;
    private bool colider = false;


    void Start()
    {
        aviso.SetActive(false);
        controles.SetActive(false);
        cartel.SetActive(true);
        teclado.SetActive(true);
        mando.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && colider == true)
        {
            controles.SetActive(true);
            Time.timeScale = 0;
            cartel.SetActive(false);
            aviso.SetActive(false);
        }

        if(Input.GetButtonDown("Cancel") && colider == true)
        {
            //controles.SetActive(false);
            //Time.timeScale = 1;
            //colider = true;
            //cartel.SetActive(true);
            //aviso.SetActive(true);
            regresar();
        }

    }

    public void regresar()
    {
        controles.SetActive(false);
        Time.timeScale = 1;
        colider = true;
        cartel.SetActive(true);
        aviso.SetActive(true);
    }

    public void modoteclado()
    {
     teclado.SetActive(true);
     mando.SetActive(false);
    }

    public void modomando()
    {
        teclado.SetActive(false);
        mando.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(true);
            colider = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(false);
            colider = false;
        }

    }

}

