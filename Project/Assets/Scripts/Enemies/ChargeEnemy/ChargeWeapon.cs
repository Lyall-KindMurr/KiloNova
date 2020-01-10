using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnMiddle;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnRight;
    public float fireTimeMin = 50f;
    public float fireTimeMax = 100f;

    private float fireTime;
    int timePassed = 0;
    bool plsfire;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }
    private void OnEnable()
    {
        fireTime = Random.Range(fireTimeMin, fireTimeMax) + 30;
        Wait();
    }

    private bool Wait()
    {
        if (timePassed < fireTime)
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

        Instantiate(bulletPrefab, bulletSpawnMiddle.position, bulletSpawnMiddle.rotation);       
        Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
        Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);

        fireTime = Random.Range(fireTimeMin, fireTimeMax);
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