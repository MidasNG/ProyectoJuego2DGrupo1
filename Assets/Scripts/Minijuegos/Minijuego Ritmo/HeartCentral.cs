using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCentral : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Animator animator;
    private int contadorRed = 0;
    private bool dentroRed = false;
    private int contadorGreen = 0;
    private bool dentroGreen = false;
    private float interact;
    private float otherInteract;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, -4, 0);

        interact = Input.GetAxisRaw("InteractGame");
        otherInteract = Input.GetAxisRaw("Interact");

        if (contadorRed == 2)
        {
            dentroRed = true;
        }
        else
        {
            dentroRed = false;
        }

        if (interact > 0)
        {
            if (dentroRed == true)
            {
                animator.SetBool("Dentro", true);
            }
            else
            {
                animator.SetBool("Dentro", false);
            }
        }

        if (contadorGreen == 2)
        {
            dentroGreen = true;
        }
        else
        {
            dentroGreen = false;
        }

        if (otherInteract > 0)
        {
            if (dentroGreen == true)
            {
                animator.SetBool("Dentro", true);
            }
            else
            {
                animator.SetBool("Dentro", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RhythmHeart")
        {
            contadorRed++;
        }

        if (collision.gameObject.tag == "RhythmHeartGreen")
        {
            contadorGreen++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RhythmHeart")
        {
            contadorRed--;
        }

        if (collision.gameObject.tag == "RhythmHeartGreen")
        {
            contadorGreen--;
        }

    }

}
