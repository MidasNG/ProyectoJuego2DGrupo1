using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opcionesinterfaz : MonoBehaviour
{
    string escenaActual;

    private void Start()
    {
        escenaActual = SceneManager.GetActiveScene().name;
    }
    
    public void Update()
    {
        if (Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Carga Apagón" || Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Carga Truck" || Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Carga Ritmo" || Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Carga Feed fish" || Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Carga trash")
        {
            pantallaMinijuegos();
        }

        if (Input.GetAxisRaw("Cancel") > 0 && escenaActual == "Menu minijuegos")
        {
            volver();
        }
    }
    public void volver()
    {
        SceneManager.LoadScene("Menu principal");
        Time.timeScale = 1;
    }

    public void minijuego1()
    {

        StartCoroutine(minijuegoApagon());
    }

    public void minijuego2()
    {
        StartCoroutine(minijuegoRitmo());
    }

    public void minijuego3()
    {
        StartCoroutine(minijuegoFeed());
    }

    public void minijuego4()
    {
        StartCoroutine(minijuegoTrash());
    }

    public void minijuego5()
    {
        StartCoroutine(minijuegoTruck());
    }

    public void pantallaMinijuegos()
    {
        SceneManager.LoadScene("Menu minijuegos");
    }


    IEnumerator minijuegoApagon()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Carga Apagón");
    }

    IEnumerator minijuegoRitmo()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Carga Ritmo");
    }

    IEnumerator minijuegoFeed()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Carga Feed fish");
    }

    IEnumerator minijuegoTruck()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Carga Truck");
    }


    IEnumerator minijuegoTrash()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Carga trash");
    }
}
