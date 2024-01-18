using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    private Animator controller;
    private Rigidbody2D rb;
    private SpriteRenderer giro;
    [SerializeField] private float speedrun;
    [SerializeField] private float speedjump;
    private bool ground = true;
    private int jumps = 1;
    private int valuejumps;
    private AudioSource jumpaudio;
    [SerializeField] private float xpositivo;
    [SerializeField] private float xnegativo;
    [SerializeField] private float ypositivo;
    [SerializeField] private float ynegativo;

    private bool withController = false;

    void Start()
    {
        controller = GetComponent<Animator>();
        giro = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        jumpaudio = GetComponent<AudioSource>();
    }


    void Update()
    {

        float joystick = Input.GetAxisRaw("JoystickHorizontal");
        float keyboard = Input.GetAxisRaw("Horizontal");

        if (Time.timeScale == 1)
        {

            if (Input.GetButtonDown("Jump") && valuejumps > 0)
            {
                rb.velocity = new Vector2( speedjump, speedjump);
                valuejumps--;
                jumpaudio.Play();

            }

            controller.SetBool("jump", Input.GetAxisRaw("Jump") != 0);


            if (ground)
            {
                valuejumps = jumps;
            }

            if (joystick != 0)
            {
                withController = true;
            } else { withController = false; }

            if (withController == false)
            {
                rb.velocity = new Vector2(speedrun * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

                controller.SetBool("run", Input.GetAxisRaw("Horizontal") != 0);

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    giro.flipX = false;
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    giro.flipX = true;
                }
            } else
            {
                rb.velocity = new Vector2(speedrun * Input.GetAxisRaw("JoystickHorizontal"), rb.velocity.y);

                controller.SetBool("run", Input.GetAxisRaw("JoystickHorizontal") != 0);

                if (Input.GetAxisRaw("JoystickHorizontal") > 0)
                {
                    giro.flipX = false;
                }
                else if (Input.GetAxisRaw("JoystickHorizontal") < 0)
                {
                    giro.flipX = true;
                }
            }
           

            transform.position = new Vector2(Mathf.Clamp((transform.position.x), xnegativo, xpositivo), Mathf.Clamp((transform.position.y), ynegativo, ypositivo));
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            ground = true;
        }
      
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("ground"))
        {
            ground = false;
        }

    }
}
