using System.Collections;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    public GameObject puntuacionPrefab; // Agrega el prefab de puntuación desde el Inspector

    private AudioSource audioSource; // Variable para el AudioSource

    // Este método se llama cuando se instancian los prefabs
    void Start()
    {
        // Buscar el objeto con el componente AudioSource en la escena
        audioSource = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioSource>();

        // Verificar si se encontró el AudioSource
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un objeto con el tag 'AudioController' o no tiene un componente AudioSource adjunto.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si colisiona con el pez
        if (other.gameObject.CompareTag("Pez"))
        {
            // Reproducir el sonido desde el objeto de sonido persistente
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Instanciar el prefab de puntuación en la posición de la comida
            Instantiate(puntuacionPrefab, transform.position, Quaternion.identity);

            // Destruir tanto la comida como el objeto del pez
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
