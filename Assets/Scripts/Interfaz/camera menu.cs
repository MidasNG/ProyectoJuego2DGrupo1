using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramenu : MonoBehaviour
{
    public Transform objetivo;


    void Start()
    {
        
    }

    
    void Update()
    {
      
        transform.position = new Vector3(Mathf.Clamp(objetivo.position.x, -30, 30), 0, -10);
        if (Input.GetButtonDown("Cancel")) Application.Quit();

    }
}
