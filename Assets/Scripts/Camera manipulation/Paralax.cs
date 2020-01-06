using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float height, startpos;
    public GameObject cam;
    public float paralaxEffect;
    public double scrollAdjustment;
    

    

    void Start()
    {
        startpos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        scrollAdjustment = scrollAdjustment * 0.01;
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.y * paralaxEffect);
        double connector = (cam.transform.position.y * (1 - paralaxEffect));
        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);


        if (connector - scrollAdjustment > startpos + height)
        {
            moveUp();
            Debug.Log("Camera is too high, moving background sprite up");
        }       
    }

    private void moveUp()
    {
        startpos += 2 * height;
    }
}
