using UnityEngine;

public class HelixBullet : MonoBehaviour
{
    public float moveSpeed = 250.0f;
    public int damage = 5;
    public bool Reversed = false;
    public float LoopLength = 1.0f;
    public float Density = 0.5f;

    private int xArgument = 0;
    
    private void OnEnable()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }


    private void Update()
    {
        xArgument++;
        if (Reversed)
            transform.position = (new Vector2(-(LoopLength * Mathf.Cos(xArgument * Density)) + transform.parent.position.x, transform.parent.position.y));
        else
            transform.position = (new Vector2((LoopLength * Mathf.Cos(xArgument * Density)) + transform.parent.position.x, transform.parent.position.y));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        //Die();
    }

    //private void OnBecameInvisible()
    //{
    //    Die();
    //}

    //private void Die()
    //{
    //    gameObject.SetActive(false);
    //}

    //private void OnDisable()
    //{
    //    CancelInvoke("Die");
    //}
}

