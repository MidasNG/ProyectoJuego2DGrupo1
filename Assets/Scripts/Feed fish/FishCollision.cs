using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si colisiona con el pez (u otro objeto que desees)
        if (other.gameObject.GetComponent<FoodCollision>() != null)
        {
            // Destruir tanto la comida como el objeto del pez
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}