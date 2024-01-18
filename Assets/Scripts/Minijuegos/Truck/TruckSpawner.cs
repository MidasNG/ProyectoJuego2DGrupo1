using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    [SerializeField] private Notification miss, correct, incorrect;
    [SerializeField] private TruckGameController game;
    [SerializeField] private GameObject badTruck, goodTruck;
    [SerializeField] private TruckAudioController audioSource;
    private GameObject lastTruckInstance;
    private TruckBehaviour lastTruckScript;
    private int truckType = 0;
    private float timeSinceLastTruck = 0;

    void Update()
    {
        if (timeSinceLastTruck > .60)
        {
            truckType = Random.Range(0, 2);
            if (truckType == 0 ) lastTruckInstance = Instantiate(badTruck, new Vector3(transform.position.x, -10, transform.position.z), Quaternion.identity, gameObject.transform);
            else lastTruckInstance = Instantiate(goodTruck, new Vector3(transform.position.x, -10, transform.position.z), Quaternion.identity, gameObject.transform);
            lastTruckScript = lastTruckInstance.GetComponent<TruckBehaviour>();
            lastTruckScript.Setup(game, miss, correct, incorrect, audioSource);
            timeSinceLastTruck = 0;
        }
        timeSinceLastTruck += Time.deltaTime;
    }
}
