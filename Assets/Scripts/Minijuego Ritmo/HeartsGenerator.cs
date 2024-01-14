using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HeartsGenerator : MonoBehaviour
{
    public Transform target;
    public GameObject prefabHeart;
    private float tiempoEntreCorazones;
    private float comienzoDeTiempo;
    private bool stop = false;

    IEnumerator Start()
    {
        stop = false;

        yield return new WaitForSecondsRealtime(33f);

        stop = true;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x - 12.19f, -4.037f, 0);


        if (stop == false)
        {
            if (tiempoEntreCorazones <= 0)
            {
                GameObject heart = Instantiate(prefabHeart, transform.position, Quaternion.identity);
                comienzoDeTiempo = Random.Range(1, 5);
                tiempoEntreCorazones = comienzoDeTiempo;
            }
            else
            {
                tiempoEntreCorazones -= Time.deltaTime;
            }
        }
        else if (stop == true)
        {
            Destroy(gameObject);
        }

    }
}
