using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modopuntuacion : MonoBehaviour
{
    public GameObject aviso;
   

    void Start()
    {
        aviso.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(true);
            
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            aviso.SetActive(false);
            
        }

    }

}

