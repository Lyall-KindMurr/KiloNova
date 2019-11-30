using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{

    public float delay = 2f;
    public float blastRadius = 5f;
    public float explosionForce = 500f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
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

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.attachedRigidbody.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }

        //remove grenade

        Destroy(gameObject);

    }
}
