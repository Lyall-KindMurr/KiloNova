using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMedium : MonoBehaviour
{
    //the silver coin is always summoned by the gold coin, so it mustn't start with any force
    //if you want to create a silver coin out of an enemy, please use CoinBig Script

    public float timeToExist = 120;
    public GameObject BronzeCoin;

    private void Update()
    {
        timeToExist--;
        if (timeToExist <= 0)
        {
            GameObject newCoin = Instantiate(BronzeCoin , this.transform.position, this.transform.rotation);
            newCoin.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity, ForceMode2D.Impulse);
            this.GetComponent<DestroyOnDie>().Die();
        }
    }
}
