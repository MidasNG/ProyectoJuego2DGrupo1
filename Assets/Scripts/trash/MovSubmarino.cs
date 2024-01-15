using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSubmarino : MonoBehaviour
{
    public SpriteRenderer sprite;

    public float velocidad = 3;
    public float value = 6;

//    void Update()
//    {
//        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

//        if (inputVector.magnitude > 1)
//        {
//            inputVector.Normalize();
//        }

//        Vector2 movementVector = inputVector * Time.deltaTime * velocidad;

//        transform.position = new Vector2(Mathf.Clamp(transform.position.x + movementVector.x, -11, 41), (Mathf.Clamp(transform.position.y + movementVector.y, 1.5f, -73)));

//    }

//}

        void Update()
        {
            float movHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * movHorizontal * velocidad * Time.deltaTime);

            float movVertical = Input.GetAxis("Vertical");
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
}
