using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleMainBullet : MonoBehaviour
{
    public float moveSpeed = 250.0f;
    public float lifeTime = 1.5f;
    public float bulletCounter = 0.05f;
    public GameObject branchExplosion;

    int spread =10;
    
    float theBulletCounter;

    private void OnEnable()

    {
        theBulletCounter = bulletCounter;
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }


    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime >= 0 ) //if the bullet is still alive
        {
            theBulletCounter -= Time.deltaTime;
            if(theBulletCounter <= 0) //the time to spawn a bullet arrived
            {
                int randomY = Random.Range(-spread, spread);
                int randomX = Random.Range(-spread, spread);

                GameObject explosion = Instantiate(branchExplosion, transform.position, transform.rotation);
                explosion.transform.Rotate(randomX, randomY, 0);
                
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
