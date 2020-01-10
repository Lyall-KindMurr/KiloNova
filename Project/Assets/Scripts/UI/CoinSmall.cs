using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSmall : MonoBehaviour
{
    //the bronze coin has a long lifespan, if you want to spawn it out of an enemy, change time to 
    //exist to a much higher value

    public float timeToExist = 180;

    private void Update()
    {
        timeToExist--;
        if (timeToExist <= 0)
        {
            this.GetComponent<DestroyOnDie>().Die();
        }
    }
}
