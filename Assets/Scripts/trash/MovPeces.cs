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
        while (t >= 0 && t <= 1)
        {
            transform.position = Vector3.Lerp(StartPosition, FinishPosition, curva.Evaluate(t));

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
        }
    }
}
