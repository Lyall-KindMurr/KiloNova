using UnityEngine;

public class CameraScroll : MonoBehaviour
{

    public Transform target;
    public float speed = 5.0f;

    void FixedUpdate()
    {
        Vector2 newPos = new Vector2(0, transform.position.y);
    }
}
