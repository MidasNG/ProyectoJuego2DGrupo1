using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class modominijuego : MonoBehaviour
{
    private bool colider=false;

    public void Start()
    {
        StartCoroutine(cambiomodo());
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            colider = true;
           
            SceneManager.LoadSceneAsync("Menu minijuegos");
        }

    }

    public IEnumerator cambiomodo()
    {
    
        if (colider == true)
        {
           
            yield return new WaitForSeconds(2);
           
            yield return 2f;

            SceneManager.LoadSceneAsync("Minijuego Apagón");

        }


    }

}
