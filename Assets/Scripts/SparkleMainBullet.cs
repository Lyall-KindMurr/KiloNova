using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleMainBullet : MonoBehaviour
{
    public float moveSpeed = 250.0f;
    public float lifeTime = 1.5f;
    public float bulletCounter = 0.15f;
    public GameObject branchExplosion;
    
    float theBulletCounter;

    private void OnEnable()

    {
        theBulletCounter = bulletCounter;
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }


    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0 ) //if the bullet is still alive
        {
            theBulletCounter -= Time.deltaTime;
            if(theBulletCounter <= 0) //the time to spawn a bullet arrived
            {
                Instantiate(branchExplosion, this.transform.position,this.transform.rotation);
                theBulletCounter = bulletCounter;
            } 
        }
         else
        {
            Destroy(gameObject);
        }

        //the bullet dies immediately?
    }

}
