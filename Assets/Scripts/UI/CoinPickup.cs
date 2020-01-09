using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public float HalfValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //for some unknown reason, this if triggers twice, giving the player double the amount of coins
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerControlledControlledMovement>().coinCount += Convert.ToInt32(HalfValue);
            this.enabled = false;
            this.GetComponent<DestroyOnDie>().Die();
        }
    }
}
