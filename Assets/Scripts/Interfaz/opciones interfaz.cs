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
        SceneManager.LoadScene("Minijuego Apagón");
    }

    public void minijuego2()
    {
        SceneManager.LoadScene("Minijuego Ritmo");
    }

    public void minijuego3()
    {
        SceneManager.LoadScene("Feed fish");
    }

    public void minijuego4()
    {
        SceneManager.LoadScene("Minijuego trash");
    }

    public void minijuego5()
    {
        SceneManager.LoadScene("Truck");
    }

    public void minijuegorandom()
    {
        nivelrandom = Random.Range(4, 8);
        SceneManager.LoadScene(nivelrandom);
    }
}
