using UnityEngine;
using UnityEngine.Events;

public class RedHealthSystem : MonoBehaviour
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

    public void TakeDamageSparkle(int damage)
    {
        health -= damage*2 ;
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
    public void TakeDamageSniper(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            onDie.Invoke();
        }
    }
    public void TakeDamageGrenade
        (int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            onDie.Invoke();
        }
    }
}


