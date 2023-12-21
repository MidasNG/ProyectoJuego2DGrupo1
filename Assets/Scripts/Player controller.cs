using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Animator controller;
    private Rigidbody2D rb;
    public float speedrun;
    public float speedjump;
    private bool ground = true;
    private int jumps = 1;
    private int valuejumps;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && valuejumps > 0)
        {
            
            rb.AddForce(new Vector2(0, speedjump), ForceMode2D.Impulse);
            
            valuejumps--;

        }


        if (ground)
        {
            valuejumps = jumps;
        }

        rb.velocity = new Vector2(speedrun * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        controller.SetBool("run", Input.GetAxisRaw("Horizontal") != 0);



    }
}
