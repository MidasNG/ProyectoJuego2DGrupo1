using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject comidaPrefab; // Prefab de la comida
    public int cantidadMaxima = 5; // Cantidad máxima de comida a generar
    public float tiempoEsperaEntreGeneraciones = 2.0f; // Tiempo de espera entre generaciones
    public float tiempoVidaComida = 5.0f; // Tiempo de vida de la comida

    private bool puedeGenerar = true;

    void Update()
    {
        // Generar comida si se puede y se presiona la barra espaciadora
        if (puedeGenerar && Input.GetKeyDown(KeyCode.Space))
        {
            GenerarComida();
            StartCoroutine(EsperarParaGenerar());
        }
    }

    void GenerarComida()
    {
        // Generar una cantidad aleatoria de comida entre 1 y cantidadMaxima
        int cantidadAGenerar = Random.Range(1, cantidadMaxima + 1);

        // Generar la cantidad de comida aleatoria
        for (int i = 0; i < cantidadAGenerar; i++)
        {
            // Generar la comida en la posición del generador (este empty object)
            GameObject nuevaComida = Instantiate(comidaPrefab, transform.position, Quaternion.identity);
            Destroy(nuevaComida, tiempoVidaComida); // Destruir la comida después de tiempoVidaComida segundos
        }
    }

    IEnumerator EsperarParaGenerar()
    {
        puedeGenerar = false;
        yield return new WaitForSeconds(tiempoEsperaEntreGeneraciones);
        puedeGenerar = true;
    }
}
