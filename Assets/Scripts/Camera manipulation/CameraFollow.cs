using UnityEngine;
using UnityEngine.Events;

[System.Serializable]


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 10.0f;
    public Camera thisCamera;
    public float speed;

    void FixedUpdate()
    {
        if (thisCamera.transform.position.y - target.position.y < 2.7)
        {
            PlayerScroll();
        }
        else
        {
            //scroll normally, according to speed

            transform.Translate(new Vector2(0, speed) * Time.deltaTime);

            //move the player the same amount as the camera, to "lock" their position on the screen

            target.transform.Translate(new Vector2(0, speed) * Time.deltaTime,Space.World);
        }
    }

    void PlayerScroll()
    {
        //follow the player, but sit 3 units above him, smoothed out by Lerp

        Vector3 newPos = new Vector3(0, target.position.y + 3, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.1f));
    }
}
