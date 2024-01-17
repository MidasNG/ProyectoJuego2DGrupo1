using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Properties;
using UnityEngine;

public class TruckBehaviour : MonoBehaviour
{
    [SerializeField] private AnimationCurve movementCurve, vanishCurve;
    [SerializeField] private TruckGameController game;
    private SpriteRenderer spriteRenderer;
    private float pointA = 0, t, vanishT = 0, pointB = 10, speed = 4;
    private bool approveable = false;
    private Notification miss, correct, incorrect;
    private bool vanish = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        StartCoroutine("MovePointA");
    }

    void Update()
    {
        //No dejar pasar a los camiones
        if (!vanish)
        {
            if (approveable && Input.GetButtonDown("Left") && Mathf.Approximately(transform.position.x, -4.2f) && Time.timeScale == 1) StartCoroutine(Vanish());

            if (approveable && Input.GetButtonDown("Right") && Mathf.Approximately(transform.position.x, 4.3f) && Time.timeScale == 1) StartCoroutine(Vanish());
        }
    }

    //Moverse desde fuera hacia dentro de la pantalla
    private IEnumerator MovePointA()
    {
        t = 0;
        while (transform.position.y < pointA)
        {
            t = Mathf.Clamp(t + Time.deltaTime * speed, 0, 1);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(-10, pointA, movementCurve.Evaluate(t)));
            if (transform.position.y >= -5) approveable = true;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(.35f);
        StartCoroutine(MovePointB());
        yield return null;
    }

    //Moverse desde dentro hacia fuera de la pantalla
    private IEnumerator MovePointB()
    {
        t = 0;
        while (!Mathf.Approximately(transform.position.y, pointB))
        {
            t = Mathf.Clamp(t + Time.deltaTime * speed, 0, 1);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(pointA, pointB, movementCurve.Evaluate(t)));
            if (transform.position.y >= 5) approveable = false;
            yield return new WaitForEndOfFrame();
        }
        VanishMiss();
    }

    //Desaparecer
    private IEnumerator Vanish()
    {
        vanish = true;
        StopCoroutine(MovePointA());
        StopCoroutine(MovePointB());
        if (spriteRenderer.color.g == 1 && !Mathf.Approximately(transform.position.y, pointB))
        {
            ScoreManager.instance.RemovePointTruck();
            incorrect.TriggerNotif();
        }
        else
        {
            ScoreManager.instance.AddPointTruck();
            correct.TriggerNotif();
        }
        vanishT = 0;
        while (spriteRenderer.color.a > 0)
        {
            vanishT = Mathf.Clamp( vanishT + Time.deltaTime * 5, 0, 1);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(1, 0, vanishCurve.Evaluate(vanishT)));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    private void VanishMiss()
    {
        if (spriteRenderer != null && spriteRenderer.color.r == 1)
        {
            if (game != null)
            {
                ScoreManager.instance.RemovePointTruck();
            }

            if (miss != null)
            {
                miss.TriggerNotif();
            }

            Destroy(gameObject);
        }
    }

    //Asociar los elementos necesarios desde el spawner
    public void Setup(TruckGameController game, Notification miss, Notification correct, Notification incorrect)
    {
        this.game = game;
        this.miss = miss;
        this.correct = correct;
        this.incorrect = incorrect;
    }
}
