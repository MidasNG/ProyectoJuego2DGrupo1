using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource music;
    IEnumerator Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();

        yield return new WaitForSecondsRealtime(23f);

        music.Stop();
    }

}
