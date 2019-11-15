using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float height, startpos;
    public GameObject cam;
    public float paralaxEffect;


    void Start()
    {
        startpos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        Debug.Log("this is a test");

        float dist = (cam.transform.position.y * paralaxEffect);
        float connector = (cam.transform.position.y * (1 - paralaxEffect));
        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);


        if (connector > startpos + height)
        {
            startpos += height;
        }
        else if (connector < startpos - height)
            startpos -= height;
    }
}
