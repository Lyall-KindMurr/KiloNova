using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
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
            HeathSystem enemy = hitInfo.transform.GetComponent<HeathSystem>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
