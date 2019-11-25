using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWeak : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float fireTime = 0.25f;
    bool fireLeft = false;
    int timePassed = 0;
    bool plsfire;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private bool Wait()
    {
        if (timePassed < 50)
        {
            timePassed++;
            return false;
        }
        else
        {
            timePassed = 0;
            return true;
        }

    }

    private void Fire()
    {
        isFiring = true;

        if (fireLeft == true)
        {
            Instantiate(bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
            fireLeft = false;
        }
        else if (fireLeft == false)
        {
            Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);
            fireLeft = true;
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private void Update()
    {
        plsfire = Wait();
        if (plsfire == true)
        {
            Fire();
        }
    }
}