using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptContador : MonoBehaviour
{
    public AudioSource win;

    public Text contadorTexto;
    private int contadorBasuras = 0;

    public static ScriptContador instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CogerBasuras()
    {
        {
            contadorBasuras++;
            contadorTexto.text = "Puntuación: " + contadorBasuras;


            //if (contadorBasuras == 10)
            //{
            //    StartCoroutine(EsperarYCambiarNivel());
            //}
        }

        //IEnumerator EsperarYCambiarNivel()
        //{
        //    yield return new WaitForSeconds(3.5f);

        //    SceneManager.LoadScene("Nivel 2");
        //}

    }
}

