using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Launcher : MonoBehaviour
{
    public GameObject grenadePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
    }

}
