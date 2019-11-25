using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movediagonal : MonoBehaviour
{
    public float speedX = 1,speedY =1;
    public Transform target;

    private void Update()
    {
        float x = target.position.x + speedX;
        float y = -target.position.y - speedY;

        transform.Translate(new Vector2(x, y) / 100.0f, Space.World);
    }
}
