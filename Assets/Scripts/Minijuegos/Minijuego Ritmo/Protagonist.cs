using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private Animator finalAnimation;
    private bool final;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        finalAnimation = GetComponent<Animator>();
    }

    void Update()
    {

        rb2d.velocity = Vector2.right * speed;

        if (final == true)
        {
            rb2d.velocity = new Vector2 (0,0);
            finalAnimation.SetBool("Final", true);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            final = true;
        }      
    }

}
