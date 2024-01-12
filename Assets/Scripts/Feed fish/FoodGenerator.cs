using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject comidaPrefab; // Prefab de la comida
    public float probabilidadGeneracion = 0.5f; // Probabilidad de generación de comida
    public float tiempoEsperaEntreGeneraciones = 2.0f; // Tiempo de espera entre generaciones
    public float tiempoVidaComida = 5.0f; // Tiempo de vida de la comida

    private bool puedeGenerar = true;

    void Update()
    {
        // Generar comida si se puede y se presiona la barra espaciadora
        if (puedeGenerar && Input.GetKeyDown(KeyCode.Space))
        {
            if (Random.value < probabilidadGeneracion)
            {
                GenerarComida();
            }

            StartCoroutine(EsperarParaGenerar());
        }
    }

    void GenerarComida()
    {
        // Generar la comida en la posición del generador (este empty object)
        GameObject nuevaComida = Instantiate(comidaPrefab, transform.position, Quaternion.identity);
        Destroy(nuevaComida, tiempoVidaComida); // Destruir la comida después de tiempoVidaComida segundos
    }

    IEnumerator EsperarParaGenerar()
    {
        puedeGenerar = false;
        yield return new WaitForSeconds(tiempoEsperaEntreGeneraciones);
        puedeGenerar = true;
    }
}
