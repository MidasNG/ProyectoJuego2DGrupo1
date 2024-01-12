using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSubmarino : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;

    public float velocidad = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.down * movHorizontal * velocidad * Time.deltaTime);

        float movVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * movVertical * velocidad * Time.deltaTime);


        //if (movHorizontal > 0)
        //{
        //    sprite.flipX = false;
        //}
        //else if (movHorizontal < 0)
        //{
        //    sprite.flipX = true;
        //}
    }
}
