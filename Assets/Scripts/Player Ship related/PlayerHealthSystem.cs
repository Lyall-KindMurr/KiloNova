using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health = 25;
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
