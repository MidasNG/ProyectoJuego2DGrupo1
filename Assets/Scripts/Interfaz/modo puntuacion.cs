using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modopuntuacion : MonoBehaviour
{
    [SerializeField] private GameObject aviso;
    private bool colider = false;

    void Start()
    {
        aviso.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && colider == true)
        {
            SceneManager.LoadSceneAsync("Menu Puntuacion");

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        colider = true;

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(true);

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        colider = false;

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(false);
        }

    }

}

