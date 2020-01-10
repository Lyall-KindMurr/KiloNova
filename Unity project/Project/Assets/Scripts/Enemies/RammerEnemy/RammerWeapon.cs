using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerWeapon : MonoBehaviour
{
    
    public GameObject slashPrefab;
    public Transform bulletSpawn;
    public float fireTimeMin = 10f;
    public float fireTimeMax = 40f;

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
        fireTime = Random.Range(fireTimeMin, fireTimeMax) + 50;
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
        Instantiate(slashPrefab, bulletSpawn.position, bulletSpawn.rotation);
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

