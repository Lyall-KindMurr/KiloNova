using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class EnemyFindPlayer : MonoBehaviour
{
    public EnemySpawnedEvent onSpawn;

    private void OnEnable()
    {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
    }
}