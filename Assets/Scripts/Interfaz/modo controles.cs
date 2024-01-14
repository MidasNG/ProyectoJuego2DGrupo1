using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modocontroles : MonoBehaviour
{
    public GameObject aviso;
    private bool colider = false;
    

    void Start()
    {
        aviso.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && colider == true)
        {
            SceneManager.LoadSceneAsync("Menu controles");

        }
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

