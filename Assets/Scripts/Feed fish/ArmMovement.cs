using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float velocidadMovimiento = 1.0f; // Velocidad ajustable desde el Inspector
    public float limiteIzquierdo = -1.0f; // L�mite izquierdo
    public float limiteDerecho = 1.0f; // L�mite derecho

    public Sprite manoCerradaSprite;
    public Sprite manoAbiertaSprite;

    private SpriteRenderer spriteRenderer;
    private bool puedePulsarSpace = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

        // Verifica si se ha presionado la tecla Space y puedePulsarSpace es true
        if (Input.GetKeyDown(KeyCode.Space) && puedePulsarSpace)
        {
            // Cambia el sprite a la mano abierta
            spriteRenderer.sprite = manoAbiertaSprite;

            // Inicia la corrutina para cerrar la mano despu�s de un tiempo
            StartCoroutine(CerrarManoDespuesDeTiempo(0.5f));
        }
    }

    IEnumerator CerrarManoDespuesDeTiempo(float tiempo)
    {
        // Indica que no se puede pulsar Space durante un segundo
        puedePulsarSpace = false;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempo);

        // Cambia el sprite de nuevo a la mano cerrada
        spriteRenderer.sprite = manoCerradaSprite;

        // Habilita la posibilidad de volver a pulsar Space
        puedePulsarSpace = true;
    }
}