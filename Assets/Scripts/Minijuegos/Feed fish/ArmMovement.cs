using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento; // Velocidad ajustable desde el Inspector
    [SerializeField] private float limiteIzquierdo; // Límite izquierdo
    [SerializeField] private float limiteDerecho; // Límite derecho

    [SerializeField] private Sprite manoCerradaSprite;
    [SerializeField] private Sprite manoAbiertaSprite;

    private SpriteRenderer spriteRenderer;
    private bool puedePulsarSpace = true;

    private bool withController = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Obtener la entrada de teclado para mover el brazo
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float joystickHorizontal = Input.GetAxisRaw("JoystickHorizontal");
        
        if (joystickHorizontal != 0)
        {
            withController = true;
        }
        else { withController = false; }
        // Calcular la posición actual del brazo
        Vector3 posicionActual = transform.position;
        if (withController == false)
        {
            // Calcular la nueva posición del brazo considerando la velocidad y el tiempo
            float movimiento = movimientoHorizontal * velocidadMovimiento * Time.deltaTime;
            float nuevaPosicionX = posicionActual.x + movimiento;

            // Aplicar los límites para el movimiento del brazo
            nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

            // Actualizar la posición del brazo
            transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
        } else
        {
            // Calcular la nueva posición del brazo considerando la velocidad y el tiempo
            float movimiento = joystickHorizontal * velocidadMovimiento * Time.deltaTime;
            float nuevaPosicionX = posicionActual.x + movimiento;

            // Aplicar los límites para el movimiento del brazo
            nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

            // Actualizar la posición del brazo
            transform.position = new Vector3(nuevaPosicionX, posicionActual.y, posicionActual.z);
        }
        

        // Verifica si se ha presionado la tecla Space y puedePulsarSpace es true
        if (Input.GetKeyDown(KeyCode.Space) && puedePulsarSpace || Input.GetButton("Jump") && puedePulsarSpace)
        {
            // Cambia el sprite a la mano abierta
            spriteRenderer.sprite = manoAbiertaSprite;

            // Inicia la corrutina para cerrar la mano después de un tiempo
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