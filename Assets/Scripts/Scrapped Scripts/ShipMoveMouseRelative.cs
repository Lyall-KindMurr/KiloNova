using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveMouseRelative : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D theObject;
    void Start()
    {
        theObject = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        theObject.transform.Translate(new Vector2(x, y) * speed / 10.0f);
        theObject.angularVelocity = 0.0f;
    }
}
