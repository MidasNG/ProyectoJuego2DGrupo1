using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    [SerializeField] private Notification miss, correct, incorrect;
    [SerializeField] private TruckGameController game;
    public GameObject truck;
    private GameObject lastTruckInstance;
    private SpriteRenderer lastTruckSprite;
    private TruckBehaviour lastTruckScript;
    private int colour = 0;
    private float timeSinceLastTruck = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (timeSinceLastTruck > .60)
        {
            lastTruckInstance = Instantiate(truck, new Vector3(transform.position.x, -10, transform.position.z), Quaternion.identity, gameObject.transform);
            lastTruckScript = lastTruckInstance.GetComponent<TruckBehaviour>();
            lastTruckScript.Setup(game, miss, correct, incorrect);
            lastTruckSprite = lastTruckInstance.GetComponent<SpriteRenderer>();
            
            colour = Random.Range(0, 2);
            if (colour == 1) lastTruckSprite.color = new Color(0, 1, 0); else lastTruckSprite.color = new Color(1, 0, 0);
            timeSinceLastTruck = 0;
        }
        timeSinceLastTruck += Time.deltaTime;
    }
}
