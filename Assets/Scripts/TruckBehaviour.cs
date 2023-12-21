using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    [SerializeField] private AnimationCurve movementCurve, vanishCurve;
    private SpriteRenderer spriteRenderer;
    private float pointA = 0, t, vanishT = 0, pointB = 10;
    Coroutine coroutine;
    private bool approveable = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Iniciar corrutinas
        if (Mathf.Approximately(transform.position.y, -10) && coroutine == null)
        {
            Coroutine coroutine = StartCoroutine("MovePointA");
        }

        if (Mathf.Approximately(transform.position.y, pointA) && coroutine == null)
        {
            Coroutine coroutine = StartCoroutine("MovePointB");
        }

    }

    void Update()
    {
        //No dejar pasar a los camiones
        if (approveable && Input.GetButtonDown("Interact")) StartCoroutine("Vanish");
    }

    //Moverse desde fuera hacia dentro de la pantalla
    private IEnumerator MovePointA()
    {
        t = 0;
        while (transform.position.y < pointA)
        {
            t = Mathf.Clamp(t + Time.deltaTime, 0, 1);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(-10, pointA, movementCurve.Evaluate(t)));
            yield return new WaitForEndOfFrame();
        }
        //Espera y permite no dejarle pasar
        approveable = true;

        yield return new WaitForSeconds(.5f);
        approveable = false;


        StartCoroutine(MovePointB());
    }

    //Moverse desde dentro hacia fuera de la pantalla
    private IEnumerator MovePointB()
    {
        t = 0;
        while (transform.position.y < pointB)
        {
            t = Mathf.Clamp(t + Time.deltaTime, 0, 1);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(pointA, pointB, movementCurve.Evaluate(t)));
            yield return new WaitForEndOfFrame();
        }

        transform.position = new Vector2(transform.position.x, -10);
        if (spriteRenderer.color.r == 1 && spriteRenderer.color.a == 1) print("Has dejado pasar a un rojo");
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(MovePointA());
    }

    //Desaparecer
    private IEnumerator Vanish()
    {
        if (spriteRenderer.color.g == 1) print("Incorrecto"); else print("Correcto");
        vanishT = 0;
        while (spriteRenderer.color.a > 0)
        {
            vanishT = Mathf.Clamp( vanishT + Time.deltaTime * 3, 0, 1);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(1, 0, vanishCurve.Evaluate(vanishT)));
            yield return new WaitForEndOfFrame();
        }
    }
}
