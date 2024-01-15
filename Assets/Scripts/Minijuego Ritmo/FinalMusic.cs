using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalMusic : MonoBehaviour
{
    private AudioSource finalMusic;

    IEnumerator Start()
    {
        finalMusic = GetComponent<AudioSource>();
        finalMusic.Pause();

        yield return new WaitForSecondsRealtime(23f);

        finalMusic.Play();
    }

}





