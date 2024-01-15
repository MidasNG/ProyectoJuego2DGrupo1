using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opcionesinterfaz : MonoBehaviour
{

    public int nivelrandom;

    public void volver()
    {
        SceneManager.LoadScene("Menu principal");
    }

    public void minijuego1()
    {
        SceneManager.LoadScene("Carga Apagón");
    }

    public void minijuego2()
    {
        SceneManager.LoadScene("Carga Ritmo");
    }

    public void minijuego3()
    {
        SceneManager.LoadScene("Carga Feed fish");
    }

    public void minijuego4()
    {
        SceneManager.LoadScene("Carga trash");
    }

    public void minijuego5()
    {
        SceneManager.LoadScene("Carga Truck");
    }

    public void minijuegorandom()
    {
        nivelrandom = Random.Range(8, 13);
        SceneManager.LoadScene(nivelrandom);
    }
}
