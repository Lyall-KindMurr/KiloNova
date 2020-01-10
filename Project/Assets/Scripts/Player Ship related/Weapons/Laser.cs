using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 50;
    public LineRenderer linerenderer;
    public LayerMask mask;
    public float fireTime = 1f;


    private bool isFiring = false;


    private void SetFiring()
    {
        isFiring = false;
    }
    private void HideLaser()
    {
        linerenderer.enabled = false;
        
    }

    private void Fire()
    {
        isFiring = true;

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 100, mask);

        if (hitInfo)
        {
            linerenderer.enabled = true;
            isFiring = true;

            Debug.Log(hitInfo.transform.name);
            RedHealthSystem enemy1 = hitInfo.transform.GetComponent<RedHealthSystem>();
            if (enemy1 != null)
            {
                enemy1.TakeDamageSniper(damage);
            }
            ChargeHealthSystem enemy2 = hitInfo.transform.GetComponent<ChargeHealthSystem>();
            if (enemy2 != null)
            {
                enemy2.TakeDamageSniper(damage);
            }
            SniperHealthSystem enemy3 = hitInfo.transform.GetComponent<SniperHealthSystem>();
            if (enemy3 != null)
            {
                enemy3.TakeDamageSniper(damage);
            }
            RammerHealthSystem enemy4 = hitInfo.transform.GetComponent<RammerHealthSystem>();
            if (enemy4 != null)
            {
                enemy4.TakeDamageSniper(damage);
            }

            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            linerenderer.enabled = true;
            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, firePoint.position + firePoint.up * 13);
        }

        Invoke("SetFiring", fireTime);
        Invoke("HideLaser", fireTime/10);
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
