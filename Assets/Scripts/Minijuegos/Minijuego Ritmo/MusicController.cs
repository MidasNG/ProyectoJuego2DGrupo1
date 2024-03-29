using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource introMusic;
    [SerializeField] private AudioSource firstSound;
    [SerializeField] private AudioSource secondSound;
    [SerializeField] private AudioClip firstClip;
    [SerializeField] private AudioClip secondClip;

    private int loop = 0;


    IEnumerator Start()
    {
        introMusic = GetComponent<AudioSource>();

        firstSound.Pause();
        secondSound.Pause();
        introMusic.Play();

        yield return new WaitForSecondsRealtime(3.5f);

        introMusic.Pause();

        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            firstSound.PlayOneShot(firstClip);

            yield return new WaitForSeconds(0.5f);

            secondSound.PlayOneShot(secondClip);

            yield return new WaitForSeconds(0.5f);

            loop++;
            
            if (loop == 12)
            {
                yield return new WaitForSeconds(0.5f);
                firstSound.PlayOneShot(firstClip);
                yield break;
            }
        }

    }

}
