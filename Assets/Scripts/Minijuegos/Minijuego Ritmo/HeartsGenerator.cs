using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HeartsGenerator : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject[] arrayPrefabHearts = new GameObject[2];
    private float tiempoEntreCorazones;
    private float comienzoDeTiempo;
    private bool stop = false;
    private bool activado = false;


    IEnumerator Start()
    {
            activado = false;

            yield return new WaitForSecondsRealtime(3f);

            activado = true;
            stop = false;

            yield return new WaitForSeconds(19f);

            stop = true;
            activado = false;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x - 12.19f, -4.037f, 0);
        if (Time.timeScale == 1)
        {
            if (stop == false)
            {
           
                if (tiempoEntreCorazones <= 0 && activado == true)
                {
                    int n = Random.Range(0, 2);
                    GameObject heart = Instantiate(arrayPrefabHearts[n], transform.position, Quaternion.identity);
                    comienzoDeTiempo = 1.5f;
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
}
