﻿using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float moveSpeed = 500.0f;
    public int damage = 5;
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();
    }

    private void OnBecameInvisible()
    {
        Die();
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
