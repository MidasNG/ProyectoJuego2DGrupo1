using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HeartsGenerator : MonoBehaviour
{
    public Transform target;
    public GameObject prefabHeart;
    public TextMeshProUGUI text;
    private float tiempoEntreCorazones;
    private float comienzoDeTiempo;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(target.position.x - 12.19f, -4.037f, 0);

        if (tiempoEntreCorazones <= 0)
        {
            GameObject heart = Instantiate(prefabHeart, transform.position, Quaternion.identity);
            heart.GetComponent<InteractiveHeart>().texto = text;
            comienzoDeTiempo = Random.Range(1, 5);
            tiempoEntreCorazones = comienzoDeTiempo;
        }
        else
        {
            tiempoEntreCorazones -= Time.deltaTime;
        }
    }
}
