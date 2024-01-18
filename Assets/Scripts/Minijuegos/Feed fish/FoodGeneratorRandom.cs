using System.Collections;
using UnityEngine;

public class FoodGeneratorRandom : MonoBehaviour
{
    [SerializeField] private GameObject comidaPrefab; // Prefab de la comida
    [SerializeField] private float probabilidadGeneracion; // Probabilidad de generación de comida
    [SerializeField] private float tiempoEsperaEntreGeneraciones; // Tiempo de espera entre generaciones
    [SerializeField] private float tiempoVidaComida; // Tiempo de vida de la comida

    private bool puedeGenerar = true;

    void Update()
    {
        // Generar comida si se puede y se presiona la barra espaciadora
        if (puedeGenerar && Input.GetKeyDown(KeyCode.Space) || puedeGenerar && Input.GetButton("Jump"))
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