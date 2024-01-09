using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    public GameObject truck;
    private GameObject lastTruckInstance;
    private SpriteRenderer lastTruckSprite;
    private int colour = 0;
    private float timeSinceLastTruck = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timeSinceLastTruck > .833)
        {
            lastTruckInstance = Instantiate(truck, new Vector3(transform.position.x, -10, transform.position.z), Quaternion.identity, gameObject.transform);
            lastTruckSprite = lastTruckInstance.GetComponent<SpriteRenderer>();
            colour = Random.Range(0, 3);
            if (colour == 2) lastTruckSprite.color = new Color(1, 0, 0); else lastTruckSprite.color = new Color(0, 1, 0);
            timeSinceLastTruck = 0;
        }
        timeSinceLastTruck += Time.deltaTime;
    }
}
