using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float velocidadMovimiento = 1.0f; // Velocidad ajustable desde el Inspector
    public float limiteIzquierdo = -1.0f; // Límite izquierdo
    public float limiteDerecho = 1.0f; // Límite derecho

    void Update()
    {
        // Obtener la entrada de teclado para mover el brazo
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular la posición actual del brazo
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posición del brazo considerando la velocidad y el tiempo
        float movimiento = movimientoHorizontal * velocidadMovimiento * Time.deltaTime;
        float nuevaPosicionX = posicionActual.x + movimiento;

        // Aplicar los límites para el movimiento del brazo
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

        // Actualizar la posición del brazo
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
}
