﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHelix : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public float fireTime = 0.5f;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
        Instantiate(bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            { Fire(); }
        }
    }
}
