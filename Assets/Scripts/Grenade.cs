using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public LayerMask Mask;
    public float throwForce = 200f;
    public float delay = 2f;
    public float blastRadius = 300f;
    public float explosionForce = 500f;
    public float damage = 10;
    

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    

    void Start()
    {
        countdown = delay;

        GetComponent<Rigidbody2D>().AddForce(transform.up * (throwForce * 2), ForceMode2D.Impulse);
    }


    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }


    void Explode()
    {
        //show explosion

        Instantiate(explosionEffect, transform.position, transform.rotation);

        //find objects

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius, Mask);
        
        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
                nearbyObject.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }

        //remove grenade

        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}
