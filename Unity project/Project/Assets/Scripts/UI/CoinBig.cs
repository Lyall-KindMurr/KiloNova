using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBig : MonoBehaviour
{
    //when the coin is spawned, it gets a random force upwards, and a random spread
    //at the end of its timeToLive, summon a silver coin,with the same transform, but also same velocity

    public float bounceSpread = 30;
    public float jumpingPower = 50;
    public float jumpingSpread = 10;
    public float timeToExist = 90;
    public GameObject SilverCoin;

    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-bounceSpread, bounceSpread));
        this.transform.rotation = rotation;
        GetComponent<Rigidbody2D>().AddForce(transform.up * (jumpingPower + Random.Range(-jumpingSpread,jumpingSpread)),ForceMode2D.Impulse);
    }

    private void Update()
    {
        timeToExist--;
        if (timeToExist<=0)
        {
            GameObject newCoin = Instantiate(SilverCoin, this.transform.position, this.transform.rotation);
            newCoin.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity, ForceMode2D.Impulse);
            this.GetComponent<DestroyOnDie>().Die();
        }
    }
}
