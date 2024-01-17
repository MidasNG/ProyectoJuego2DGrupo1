using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FinalMusic : MonoBehaviour
{
    private AudioSource finalMusic;
    private string nombreDeLaSiguienteEscena = "Menu minijuegos";


    IEnumerator Start()
    {
        finalMusic = GetComponent<AudioSource>();
        finalMusic.Pause();

        yield return new WaitForSeconds(20f);

        finalMusic.Play();

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(nombreDeLaSiguienteEscena);
    }

}





