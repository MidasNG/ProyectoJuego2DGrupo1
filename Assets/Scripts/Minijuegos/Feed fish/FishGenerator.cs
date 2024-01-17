using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject pezPrefab; // Prefab del pez
    public float velocidad = 2.0f; // Velocidad del pez
    public float limiteIzquierdo = -5.0f; // L�mite izquierdo
    public float limiteDerecho = 5.0f; // L�mite derecho
    public float alturaMaxima = 5.0f; // Altura m�xima en el eje Y
    public float alturaMinima = -5.0f; // Altura m�nima en el eje Y
    public bool moverHaciaDerecha = true; // Direcci�n de movimiento
    public float intervaloGeneracion = 2.0f; // Intervalo de generaci�n en segundos
    public float tamanoMinimo = 0.5f; // Tama�o m�nimo del pez
    public float tamanoMaximo = 2.0f; // Tama�o m�ximo del pez

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
        // Calcular una posici�n aleatoria en el eje Y dentro del rango establecido
        float alturaAleatoria = Random.Range(alturaMinima, alturaMaxima);
        Vector3 posicionInicial = new Vector3(transform.position.x, alturaAleatoria, transform.position.z);

        // Generar el pez en la posici�n aleatoria
        GameObject nuevoPez = Instantiate(pezPrefab, posicionInicial, Quaternion.identity);

        // Obtener el componente Rigidbody2D del pez
        Rigidbody2D rbPez = nuevoPez.GetComponent<Rigidbody2D>();

        // Agregar un Rigidbody2D si no existe
        if (rbPez == null)
        {
            rbPez = nuevoPez.AddComponent<Rigidbody2D>();
        }

        // Establecer el tama�o aleatorio del pez
        float tamanoAleatorio = Random.Range(tamanoMinimo, tamanoMaximo);
        nuevoPez.transform.localScale = new Vector3(tamanoAleatorio, tamanoAleatorio, 1f);

        // Establecer la velocidad inicial del pez seg�n la direcci�n definida
        rbPez.velocity = (moverHaciaDerecha ? Vector2.right : Vector2.left) * velocidad;

        // Destruir el pez cuando llegue a los l�mites establecidos
        Destroy(nuevoPez, Mathf.Abs(limiteIzquierdo - limiteDerecho) / velocidad);
    }
}