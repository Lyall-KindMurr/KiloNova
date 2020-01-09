using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 50;
    public LineRenderer linerenderer;
    public LayerMask mask;


    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 100, mask);

        if (hitInfo)
        {
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
            ChargeHealthSystem enemy3 = hitInfo.transform.GetComponent<ChargeHealthSystem>();
            if (enemy2 != null)
            {
                enemy2.TakeDamageSniper(damage);
            }
            ChargeHealthSystem enemy4 = hitInfo.transform.GetComponent<ChargeHealthSystem>();
            if (enemy2 != null)
            {
                enemy2.TakeDamageSniper(damage);
            }

            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, firePoint.position + firePoint.up *20);
        }

        linerenderer.enabled = true;

        yield return new WaitForSeconds(0.10f);

        linerenderer.enabled = false;
    }
}
