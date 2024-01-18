using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarControles : MonoBehaviour
{
    [SerializeField] private modocontroles cerrar;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            cerrar.regresar();
        }
    }
}
