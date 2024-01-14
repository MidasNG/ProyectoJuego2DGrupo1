using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HeartsGenerator : MonoBehaviour
{
    public Transform target;
    public GameObject[] arrayPrefabHearts = new GameObject[2];
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
                int n = Random.Range(0, 2);
                GameObject heart = Instantiate(arrayPrefabHearts[n], transform.position, Quaternion.identity);
                comienzoDeTiempo = 1f;
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
