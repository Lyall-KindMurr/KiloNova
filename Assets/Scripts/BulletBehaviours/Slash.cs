using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamageSlash", damage, SendMessageOptions.DontRequireReceiver);
    }


}
