using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pezPrefab; // Prefab del pez
    [SerializeField] private float velocidad = 2.0f; // Velocidad del pez
    [SerializeField] private float limiteIzquierdo = -5.0f; // Límite izquierdo
    [SerializeField] private float limiteDerecho = 5.0f; // Límite derecho
    [SerializeField] private float alturaMaxima = 5.0f; // Altura máxima en el eje Y
    [SerializeField] private float alturaMinima = -5.0f; // Altura mínima en el eje Y
    [SerializeField] private bool moverHaciaDerecha = true; // Dirección de movimiento
    [SerializeField] private float intervaloGeneracion = 2.0f; // Intervalo de generación en segundos
    [SerializeField] private float tamanoMinimo = 0.5f; // Tamaño mínimo del pez
    [SerializeField] private float tamanoMaximo = 2.0f; // Tamaño máximo del pez

    void Start()
    {
        StartCoroutine(GenerarPecesConIntervalo());
    }

    IEnumerator GenerarPecesConIntervalo()
    {
        while (true)
        {
            GenerarPez();
            yield return new WaitForSeconds(intervaloGeneracion);
        }
    }

    void GenerarPez()
    {
        // Calcular una posición aleatoria en el eje Y dentro del rango establecido
        float alturaAleatoria = Random.Range(alturaMinima, alturaMaxima);
        Vector3 posicionInicial = new Vector3(transform.position.x, alturaAleatoria, transform.position.z);

        // Generar el pez en la posición aleatoria
        GameObject nuevoPez = Instantiate(pezPrefab, posicionInicial, Quaternion.identity);

        // Obtener el componente Rigidbody2D del pez
        Rigidbody2D rbPez = nuevoPez.GetComponent<Rigidbody2D>();

        // Agregar un Rigidbody2D si no existe
        if (rbPez == null)
        {
            rbPez = nuevoPez.AddComponent<Rigidbody2D>();
        }

        // Establecer el tamaño aleatorio del pez
        float tamanoAleatorio = Random.Range(tamanoMinimo, tamanoMaximo);
        nuevoPez.transform.localScale = new Vector3(tamanoAleatorio, tamanoAleatorio, 1f);

        // Establecer la velocidad inicial del pez según la dirección definida
        rbPez.velocity = (moverHaciaDerecha ? Vector2.right : Vector2.left) * velocidad;

        // Destruir el pez cuando llegue a los límites establecidos
        Destroy(nuevoPez, Mathf.Abs(limiteIzquierdo - limiteDerecho) / velocidad);
    }
}