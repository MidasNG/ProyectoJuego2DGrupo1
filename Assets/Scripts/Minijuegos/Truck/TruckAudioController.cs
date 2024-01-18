using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip correctSound, incorrectSound, missSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void IncorrectSound()
    {
        audioSource.PlayOneShot(incorrectSound);
    }

    public void MissSound()
    {
        audioSource.PlayOneShot(missSound);
    }
}
