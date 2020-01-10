using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HeathSystem : MonoBehaviour
{
    public int health = 15;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;
    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    public void TakeDamageSlash(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            onDie.Invoke();
        }
    }


}

