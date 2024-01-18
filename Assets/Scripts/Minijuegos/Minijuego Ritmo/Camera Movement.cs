using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        transform.position = new Vector3(target.position.x, 0, -10);
    }
}
