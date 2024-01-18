using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckStartCountdown : MonoBehaviour
{
    [SerializeField] private GameObject audioSource, game, spawnerA, spawnerB;
    void Start()
    {
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(4);
        audioSource.SetActive(true);
        game.SetActive(true);
        spawnerA.SetActive(true);
        spawnerB.SetActive(true);
    }
}
