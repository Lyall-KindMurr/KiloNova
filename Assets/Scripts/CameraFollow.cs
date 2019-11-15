using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;


    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.1f));
    }
}
