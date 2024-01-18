using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarControles : MonoBehaviour
{
    public modocontroles cerrar;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            cerrar.regresar();
        }
    }
}
