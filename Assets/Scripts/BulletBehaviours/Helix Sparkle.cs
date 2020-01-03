using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixSparkle : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public int damage = 10;
    public bool reversed = false;
    public float loopLength = 1.0f;
    public float Density = 0.5f;

    private int xArgument = 0;

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }

    private void Update()
    {
        xArgument++;
        if (reversed)
            transform.position = (new Vector2(-(loopLength * Mathf.Cos(xArgument * Density)) + transform.parent.position.x, transform.parent.position.y));
        else
            transform.position = (new Vector2((loopLength * Mathf.Cos(xArgument * Density)) + transform.parent.position.x, transform.parent.position.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
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
