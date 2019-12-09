using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleBullet : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public int damage = 10;

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

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
