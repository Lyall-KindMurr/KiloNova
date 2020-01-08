using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedown : MonoBehaviour
{
    public float speedx;
    public float speedy;
    void Update()
    {
        this.transform.Translate(new Vector2(speedx, speedy) / 10.0f, Space.World);
    }
}
