using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 10.0f;


    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(0, target.position.y + 3, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.1f));
    }
}
