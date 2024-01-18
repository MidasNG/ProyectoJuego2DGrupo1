using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject comidaPrefab; // Prefab de la comida
    public float tiempoEsperaEntreGeneraciones = 2.0f; // Tiempo de espera entre generaciones
    public float tiempoVidaComida = 5.0f; // Tiempo de vida de la comida
    public AudioSource audioSource; // Referencia al componente AudioSource

    private bool puedeGenerar = true;

    void Start()
    {
        // Aseg�rate de asignar el componente AudioSource desde el Inspector
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no est� asignado en el Inspector.");
        }
    }

    void Update()
    {
        // Generar comida si se puede y se presiona la barra espaciadora
        if (puedeGenerar && Input.GetKeyDown(KeyCode.Space))
        {
            GenerarComida();
            ReproducirSonido();
            StartCoroutine(EsperarParaGenerar());
        }
    }

    void GenerarComida()
    {
        // Generar la comida en la posici�n del generador (este empty object)
        GameObject nuevaComida = Instantiate(comidaPrefab, transform.position, Quaternion.identity);
        Destroy(nuevaComida, tiempoVidaComida); // Destruir la comida despu�s de tiempoVidaComida segundos
    }

    void ReproducirSonido()
    {
        if (audioSource != null)
        {
            // Reproducir el sonido
            audioSource.Play();
        }
    }

    IEnumerator EsperarParaGenerar()
    {
        puedeGenerar = false;
        yield return new WaitForSeconds(tiempoEsperaEntreGeneraciones);
        puedeGenerar = true;
    }
}
