using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encender : MonoBehaviour
{

    public GameObject dark;
    public GameObject dark2;
    public Animator palanca;
    public Animator lightup;
   

    // Start is called before the first frame update
    void Start()
    {
        dark.SetActive(true);
        
        dark2.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dark.SetActive(false);
            
            dark2.SetActive(true);
            palanca.SetTrigger("activar");
            lightup.SetTrigger("encender");
        }
    }
}
