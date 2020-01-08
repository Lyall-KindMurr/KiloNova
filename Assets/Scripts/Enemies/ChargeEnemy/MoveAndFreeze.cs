using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFreeze : MonoBehaviour
{
    public float speedx;
    public float speedy;
    public float time;

    void Update()
    {
        this.transform.Translate(new Vector2(speedx, speedy) / 10.0f, Space.World);
        time -= Time.deltaTime;
        if (time<0)
        {
            this.GetComponent<MoveAndFreeze>().enabled = false;
        }
    }
}
