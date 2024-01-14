using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCentral : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private int contador = 0;
    private bool dentro = false;
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

        if (contador == 2)
        {
            dentro = true;
        }
        else
        {
            dentro = false;
        }

        if (interact > 0 || otherInteract > 0)
        {
            if (dentro == true)
            {
                animator.SetBool("Dentro", true);
            }else
            {
                animator.SetBool("Dentro", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RhythmHeart")
        {
            contador++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RhythmHeart")
        {
            contador--;
        }

    }

}
