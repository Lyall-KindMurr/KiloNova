using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public float adjustmentAngle = 0;
    public void Spawn()
    {
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;
        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
        Instantiate(Coin, transform.position, rotationInRadians);
    }
}