using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private float interact;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        interact = Input.GetAxisRaw("Interact2");

        rb2d.velocity = Vector2.right * speed;

        if(interact > 0)
        {
            speed = +9;
        }else if (interact == 0)
        {
            speed = 3;
        }
        
    }
}
