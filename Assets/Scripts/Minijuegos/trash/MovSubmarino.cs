using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSubmarino : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private float velocidad;
    //private float value = 6;

    private bool withController = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        float joystickHorizontal = Input.GetAxisRaw("JoystickHorizontal");
        float joystickVertical = Input.GetAxisRaw("JoystickVertical");

        if (joystickHorizontal != 0 || joystickVertical != 0)
        {
            withController = true;
        }
        else { withController = false; }

        if (withController == false)
        {
            transform.Translate(Vector2.right * movHorizontal * velocidad * Time.deltaTime);


            transform.Translate(Vector2.up * movVertical * velocidad * Time.deltaTime);


            if (movHorizontal > 0)
            {
                sprite.flipX = false;
            }
            else if (movHorizontal < 0)
            {
                sprite.flipX = true;
            }
        }
            else
        {
            transform.Translate(Vector2.right * joystickHorizontal * velocidad * Time.deltaTime);


            transform.Translate(Vector2.up * joystickVertical * velocidad * Time.deltaTime);


            if (joystickHorizontal > 0)
            {
                sprite.flipX = false;
            }
            else if (joystickHorizontal < 0)
            {
                sprite.flipX = true;
            }
         }

    }
}

