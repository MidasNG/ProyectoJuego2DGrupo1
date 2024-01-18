using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class MovimientoPez : MonoBehaviour
{
    //public Vector3 StartPosition;
    //public Vector3 FinishPosition;
    //private float t = 0;

    //public float velocidad;
    //private bool positive;

    //private bool movement = true;
  
    //public AnimationCurve curva;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if (movement)
    //    {
    //        print ("movimiento"); 

    //        if (!positive)
    //        {
                
    //            t = Mathf.Clamp01(t - velocidad * Time.deltaTime);
    //        }
    //        else
    //        {
    //            t = Mathf.Clamp01(t + velocidad * Time.deltaTime);
    //        }

    //        if (t >= 1 || t <= 0)
    //        {
    //            positive = !positive;
    //        }

    //        transform.position = Vector3.Lerp(StartPosition, FinishPosition, curva.Evaluate(t));
    //    }
    //}

    
    [SerializeField] private float distancia;
    [SerializeField] private float velocidad;

    private SpriteRenderer sprite;

    private bool moviendoseHaciaDerecha = true;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (moviendoseHaciaDerecha)
        {
            MoverDerecha();
        }
        else
        {
            MoverIzquierda();
        }

        // Verifica si ha alcanzado la distancia máxima y cambia la dirección
        if (transform.position.x >= distancia && moviendoseHaciaDerecha)
        {
            moviendoseHaciaDerecha = false;
        }

        else if (transform.position.x <= -distancia && !moviendoseHaciaDerecha)
        {
            moviendoseHaciaDerecha = true;
        }
    }

    void MoverDerecha()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        sprite.flipX = false;
    }

    void MoverIzquierda()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        sprite.flipX = true;
    }
}
