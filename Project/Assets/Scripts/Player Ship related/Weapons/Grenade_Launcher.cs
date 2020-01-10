using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Launcher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float fireTime = 0.75f;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;

        Instantiate(grenadePrefab, transform.position, transform.rotation);

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