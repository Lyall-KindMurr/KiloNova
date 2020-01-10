using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleBullet : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public int damage = 5;

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamageSparkle", damage, SendMessageOptions.DontRequireReceiver);

    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke("Die");
    }
}
