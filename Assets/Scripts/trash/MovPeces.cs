using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovPeces : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 FinishPosition;
    private float t = 0;

    public float velocidad;
    private bool positive;

    public AnimationCurve curva;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        //t = Mathf.Clamp01(t + velocidad * Time.deltaTime);
        //transform.position = Vector3.Lerp(StartPosition, FinishPosition, t);
        // esto hace que vaya hacia 1 lado

        t += velocidad * Time.deltaTime;

        transform.position = Vector3.Lerp(StartPosition, FinishPosition, curva.Evaluate(Mathf.PingPong(t, 1)));


        //en la funcion pingpong, 3.2 equivale a 3 caminos y 0.2 de camino

        if (positive)
        {
            t = Mathf.Clamp01(t + velocidad * Time.deltaTime);
        }
        else
        {
            t = Mathf.Clamp01(t - velocidad * Time.deltaTime);
        }

        if (t >= 1 || t <= 0)
        {
            positive = !positive;
        }

        transform.position = Vector3.Lerp(StartPosition, FinishPosition, curva.Evaluate(t));


    }
}
