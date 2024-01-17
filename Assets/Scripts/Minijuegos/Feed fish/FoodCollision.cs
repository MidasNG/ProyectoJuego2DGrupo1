using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    public GameObject puntuacionPrefab; // Agrega el prefab de puntuación desde el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si colisiona con el pez
        if (other.gameObject.CompareTag("Pez"))
        {
            // Instanciar el prefab de puntuación en la posición de la comida
            Instantiate(puntuacionPrefab, transform.position, Quaternion.identity);
            
            // Destruir tanto la comida como el objeto del pez
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
