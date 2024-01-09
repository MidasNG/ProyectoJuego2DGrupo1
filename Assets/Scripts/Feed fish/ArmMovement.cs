using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float velocidadMovimiento = 1.0f; // Velocidad ajustable desde el Inspector
    public float limiteIzquierdo = -1.0f; // L�mite izquierdo
    public float limiteDerecho = 1.0f; // L�mite derecho

    void Update()
    {
        // Obtener la entrada de teclado para mover el brazo
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular la posici�n actual del brazo
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posici�n del brazo considerando la velocidad y el tiempo
        float movimiento = movimientoHorizontal * velocidadMovimiento * Time.deltaTime;
        float nuevaPosicionX = posicionActual.x + movimiento;

        // Aplicar los l�mites para el movimiento del brazo
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

        // Actualizar la posici�n del brazo
        transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
    }
}
