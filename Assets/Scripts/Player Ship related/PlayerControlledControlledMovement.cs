using UnityEngine;

public class PlayerControlledControlledMovement : MonoBehaviour
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

        theObject.transform.Translate(new Vector2(x, y) * speed / 10.0f, Space.World);
        theObject.angularVelocity = 0.0f;
    }
}
